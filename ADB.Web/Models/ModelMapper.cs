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
        } 
    }
}