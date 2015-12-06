using ADB.Common.Dto;
using ADB.Common.Item;
using AutoMapper;

namespace ADB.Web.Models
{
    public class ModelMapper
    {
        public ModelMapper()
        {
            Mapper.CreateMap<ClientDto, ClientModel>();
            Mapper.CreateMap<ClientModel, ClientDto>();
            Mapper.CreateMap<ClientListItem, ClientListItemModel>();

            Mapper.CreateMap<ContractDto, ContractModel>();
            Mapper.CreateMap<ContractModel, ContractDto>();

            Mapper.CreateMap<DepositContractDto, DepositContractModel>();
            Mapper.CreateMap<DepositContractModel, DepositContractDto>();

            Mapper.CreateMap<CreditContractDto, CreditContractModel>();
            Mapper.CreateMap<CreditContractModel, CreditContractDto>();

            Mapper.CreateMap<DepositContractListItem, DepositContractListItemModel>();
            Mapper.CreateMap<CreditContractListItem, CreditContractListItemModel>();
        } 
    }
}