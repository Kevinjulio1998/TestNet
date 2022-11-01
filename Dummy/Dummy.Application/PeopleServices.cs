using AutoMapper;
using Dummy.Domain.Dtos;
using Dummy.Domain.IGeneric;
using Dummy.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Application
{
    public class PeopleServices : IPeopleServices
    {
        private readonly IRepository<TypeContact> _selectContact;
        private readonly IRepository<LogContact> _logContact;
        private readonly IRepository<People> _people;
        private readonly IRepository<ContactInformation> _contactInfo;
        private readonly IMapper _imapper;
        public PeopleServices(IRepository<TypeContact> selectContact,  IMapper imapper, IRepository<LogContact> logContact, IRepository<People> people, IRepository<ContactInformation> contactInfo)
        {
            _selectContact = selectContact;
            _imapper = imapper;
            _logContact = logContact;
            _people = people;
            _contactInfo = contactInfo;
        }
        public async Task<IEnumerable<TypeContact>> GetContactAsync()
        {
            var resultArea = await _selectContact.GetAsync();
            return  _imapper.Map<IEnumerable<TypeContact>>(resultArea);
        }

        public async Task<IEnumerable<People>> GetPeopleAsync()
        {
            return _imapper.Map<IEnumerable<People>>(await _people.GetAsync());
        }
        public async Task<IEnumerable<LogContact>> _GetLogContactAsync()
        {
            return _imapper.Map<IEnumerable<LogContact>>(await _logContact.GetAsync());
        }
        public async Task<IEnumerable<ContactInformationDtoView>> GetInfoContacAsync(int id)
        {
            var contacInfo = await _contactInfo.GetAsync();
            var typeContacts = await _selectContact.GetAsync();

            var result = (from a in contacInfo
                          where a.IdPeople == id
                join b in typeContacts on a.IdTypeContact equals b.Id
                select new ContactInformationDtoView
                {
                 Type   = b.Description,
                  Contact  = a.Contact
                }).ToList();


            return result;
        }

        public async Task<LogContact> _AddLogContactasync(LogContact entity)
        {
            var saveLog = await _logContact.CreateAsync(entity);
            return saveLog;
        }

        public async Task<PeopleDto> AddPeople(PeopleDto entity)
        {
           
            PeopleDto returnDtos = new PeopleDto();
            var validate = await ValidateDocument(entity.Document);
            if (validate == 0)
            {
                var mapper = _imapper.Map<People>(entity);
                var resultSave = await _people.CreateAsync(mapper);
                foreach (var item in entity.ContactInformation)
                {
                    var contactInformation = new ContactInformationDto()
                    {
                        IdPeople = mapper.Id,
                        IdTypeContact = item.IdTypeContact,
                        Contact = item.Contact
                    };
                    var mapper2 = _imapper.Map<ContactInformation>(contactInformation);
                    await _contactInfo.CreateAsync(mapper2);
                }

                return _imapper.Map<PeopleDto>(resultSave);
            }

            return returnDtos;
        }

        public async Task<int> ValidateDocument(string document)
        {
            var getDocument = await _people.GetAsync();
            var validate = getDocument.Count(x => x.Document == document);

            return validate;
        }

    }
}
