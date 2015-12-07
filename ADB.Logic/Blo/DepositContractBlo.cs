using System.Collections.Generic;
using ADB.Common.Dto;
using ADB.Common.Immutable;
using ADB.Common.Item;
using ADB.Common.Requests;
using ADB.Data.Common;
using ADB.Data.Entity;
using AutoMapper;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class DepositContractBlo:BloBase<DepositContractEntity>
    {
        public DepositContractBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveDepositContractRequest>(CreateDepositeContract);
            RegisterCommand<DepositContractListRequest>(GetDepositList);
        }

        private ExecutionResult GetDepositList(DepositContractListRequest request, ExecutionContext context)
        {
            return new ExecutionResult<IList<DepositContractListItem>>
            {
                TypedResult = AdbRepository.DepositContractData.GetDeposits(request.Paging)
            };
        }

        public AdbRepository AdbRepository => (AdbRepository) Repository;

        private ExecutionResult CreateDepositeContract(SaveDepositContractRequest request, ExecutionContext context)
        {
            ExecutionResult<DepositContractEntity> result = context.PreviousResult as ExecutionResult<DepositContractEntity>;
            DepositContractDto dto = request.Value as DepositContractDto;
            if (dto == null)
            {
                return null;
            }
            var entity = Mapper.Map<DepositContractEntity>(dto);
            AdbRepository.DepositContractData.Save(entity);
            return new ExecutionResult();
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}