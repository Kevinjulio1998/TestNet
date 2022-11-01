using System.Collections.Generic;
using System.Threading.Tasks;
using Dummy.Domain.Dtos;
using Dummy.Domain.Models;

namespace Dummy.Application
{
    public interface IPeopleServices
    {
        Task<IEnumerable<TypeContact>> GetContactAsync();

        Task<IEnumerable<LogContact>> _GetLogContactAsync();

        Task<PeopleDto> AddPeople(PeopleDto entity);
        Task<LogContact> _AddLogContactasync(LogContact entity);

        Task<IEnumerable<People>> GetPeopleAsync();
        Task<IEnumerable<ContactInformationDtoView>>  GetInfoContacAsync(int id);

        Task<int> ValidateDocument(string document);

    }
}
