using AutoMapper;
using Dummy.Domain.Dtos;
using Dummy.Domain.Models;

namespace Dummy.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<People, PeopleDto>();
            CreateMap<PeopleDto, People>();

            CreateMap<ContactInformation, ContactInformationDto>();
            CreateMap<ContactInformationDto, ContactInformation>();
            
        }
    }
}
