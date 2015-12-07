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

            Mapper.CreateMap<CardEntity, CardDto>();
            Mapper.CreateMap<CardDto, CardEntity>();

            Mapper.CreateMap<ContractEntity, ContractDto>();
            Mapper.CreateMap<ContractDto, ContractEntity>();

            Mapper.CreateMap<DepositContractEntity, DepositContractDto>();
            Mapper.CreateMap<DepositContractDto, DepositContractEntity>();

            Mapper.CreateMap<CreditContractEntity, CreditContractDto>();
            Mapper.CreateMap<CreditContractDto, CreditContractEntity>();
        }
    }
}
