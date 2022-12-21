using AutoMapper;
using Entities.Models;
using Shared.DataTransferObject;

namespace FaultServiceApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Source -> Destination
            CreateMap<Fault, FaultForReadDto>();
            CreateMap<FaultForCreationDto, Fault>();
            CreateMap<FaultForUpdateDto, Fault>();
        }
    }
}
