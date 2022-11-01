using Dummy.Application;
using Dummy.Domain.Dtos;
using Dummy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Dummy.Models;
namespace Dummy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeopleServices _services;
        public HomeController( IPeopleServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _services.GetPeopleAsync());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }
        public async Task<IActionResult> Create()
        {
            try
            {
                PeopleDto employeeDtos = new PeopleDto
                {
                    TypeContact = await _services.GetContactAsync(),
                };
                return View(employeeDtos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create(PeopleDto entity)
        {
            try
            {
                var getLogContacts = await _services._GetLogContactAsync();
              dynamic countContact = getLogContacts.Where(a => a.Document == entity.Document);
              entity.ContactInformation = countContact;

            await _services.AddPeople(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Redirect("Index");

        }
        public async Task<int> ValidateContact(LogContact logContact)
        {
            var exisDocument = await _services.ValidateDocument(logContact.Document);
            int response;
            if (exisDocument == 0)
            {
                 response = (int)ErrorCode.NulDocument;

                if (logContact.Document != null)
                {
                    var getLogContacts = await _services._GetLogContactAsync();

                    int count = 0;
                    foreach (var a in getLogContacts)
                    {
                        if (a.IdTypeContact == logContact.IdTypeContact && a.Document == logContact.Document) count++;
                    }

                    var countContact = count + 1;

                    if (countContact >= 2)
                    {
                        response = (int)ErrorCode.ContactMax;
                    }

                    if (countContact <= 2)
                    {
                        await _services._AddLogContactasync(logContact);
                        response = (int)ErrorCode.Registration;
                    }
                }
            }
            else
            {
                response = (int)ErrorCode.DocumentExis;
            }

            

            return response;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employeeDtos = await _services.GetInfoContacAsync(id);
            return View(employeeDtos);

        }

    }
}
