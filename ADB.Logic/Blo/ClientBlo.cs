using System.Collections.Generic;
using ADB.Common.Dto;
using ADB.Common.Immutable;
using ADB.Common.Item;
using ADB.Common.Requests;
using ADB.Data.Common;
using ADB.Data.Entity;
using AutoMapper;
using Levshits.Data.Common;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class ClientBlo : BloBase<ClientEntity>
    {
        protected AdbRepository AdbRepository => (AdbRepository) Repository;
        public override int Priority => PriorityLevels.FIRST_LEVEL;
        public ClientBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveClientRequest>(SaveClientEntity);
            RegisterCommand<ClientListRequest>(GetClientListItems);
            RegisterCommand<ClientByIdRequest>(GetClientById);
            RegisterCommand<DeleteClientByIdRequest>(DeleteClientById);
        }

        private ExecutionResult DeleteClientById(DeleteClientByIdRequest request, ExecutionContext context)
        {
            AdbRepository.ClientData.Delete(request.Value);
            return new ExecutionResult();
        }

        private ExecutionResult<ClientDto> GetClientById(ClientByIdRequest request, ExecutionContext context)
        {
            var entity = AdbRepository.ClientData.GetEntityById(request.Value);
            return new ExecutionResult<ClientDto>() {TypedResult = Mapper.Map<ClientDto>(entity)};
        }


        public ExecutionResult SaveClientEntity(SaveClientRequest request, ExecutionContext context)
        {
            var dto = (ClientDto) request.Value;
            var entity = dto.Id > 0 ? AdbRepository.ClientData.GetEntityById(dto.Id) : CreateEntity();
            Mapper.Map(dto, entity);
            AdbRepository.ClientData.GetClients(new PagingOptions {ItemsPerPage = 10, Page = 1});
            AdbRepository.ClientData.Save(entity);
            return new ExecutionResult();
        }

        public ExecutionResult<IList<ClientListItem>> GetClientListItems(ClientListRequest request, ExecutionContext context)
        {
            return new ExecutionResult<IList<ClientListItem>>
            {
                TypedResult = AdbRepository.ClientData.GetClients(request.Paging)
            };
        }
    }
}
