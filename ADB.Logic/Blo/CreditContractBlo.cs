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
    public class CreditContractBlo:BloBase<CreditContractEntity>
    {
        public CreditContractBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveCreditContractRequest>(CreateCreateContract);
            RegisterCommand<CreditContractListRequest>(GetCreditsList);
            RegisterCommand<CloseDayRequest>(CloseDayHandler);
        }

        private ExecutionResult CloseDayHandler(CloseDayRequest request, ExecutionContext handler)
        {
            throw new System.NotImplementedException();
        }

        public AdbRepository AdbRepository => (AdbRepository) Repository;

        public override int Priority => PriorityLevels.FIRST_LEVEL;
        private ExecutionResult CreateCreateContract(SaveCreditContractRequest request, ExecutionContext context)
        {
            ExecutionResult<CreditContractEntity> result = context.PreviousResult as ExecutionResult<CreditContractEntity>;
            CreditContractDto dto = request.Value as CreditContractDto;
            if (dto == null)
            {
                return null;
            }
            var entity = Mapper.Map<CreditContractEntity>(dto);
            entity.ContractType = (int) ContractTypeEnum.CreditContract;
            AdbRepository.CreditContractData.Save(entity);
            return new ExecutionResult();
        }

        private ExecutionResult GetCreditsList(CreditContractListRequest request, ExecutionContext context)
        {
            return new ExecutionResult<IList<CreditContractListItem>>
            {
                TypedResult = AdbRepository.CreditContractData.GetCredits(request.Paging)
            };
        }
    }
}