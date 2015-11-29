using ADB.Common.Dto;
using ADB.Data.Entity;
using AutoMapper;

namespace ADB.Data.Mappers
{
    public class DtoMap
    {
        public DtoMap()
        {
            Mapper.CreateMap<ClientEntity, ClientDto>();
            Mapper.CreateMap<ClientDto, ClientEntity>();
            Mapper.CreateMap<CityDto, CityEntity>();
            Mapper.CreateMap<CityEntity, CityDto>();
        }
    }
}
