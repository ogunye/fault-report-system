using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace FaultServiceApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Source -> Destination
            CreateMap<Fault, FaultReadDto>();
            CreateMap<FaultCreateDto, Fault>();
            CreateMap<FaultUpdateDto, Fault>();
        }
    }
}
