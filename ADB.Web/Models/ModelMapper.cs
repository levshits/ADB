using ADB.Common.Dto;
using ADB.Common.Item;
using ADB.Data.Entity;
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

            Mapper.CreateMap<CardListItem, CardListItemModel>();
            Mapper.CreateMap<CardListItemModel, CardListItem>();

            Mapper.CreateMap<AccountDto, AccountEntity>();
            Mapper.CreateMap<AccountEntity, AccountDto>();

            Mapper.CreateMap<CardDto, CardEntity>();
            Mapper.CreateMap<CardEntity, CardDto>();

            Mapper.CreateMap<CardDto, CardModel>();
            Mapper.CreateMap<CardModel, CardDto>();

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