using ADB.Common.Dto;
using ADB.Common.Immutable;
using ADB.Common.Requests;
using ADB.Data.Entity;
using Levshits.Logic;
using Levshits.Logic.Common;

namespace ADB.Logic.Blo
{
    public class AccountBlo: BloBase<AccountEntity>
    {
        public AccountBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveCreditContractRequest>(CreateCreditContract);
            RegisterCommand<SaveDepositContractRequest>(CreateDepositeContract);
        }

        public ExecutionResult CreateCreditContract(SaveCreditContractRequest request, ExecutionContext context)
        {
            ExecutionResult<CreditContractEntity> result = context.PreviousResult as ExecutionResult<CreditContractEntity>;
            if (result == null)
                return null;
            CreditContractDto dto = request.Value as CreditContractDto;

            if (dto == null)
                return null;

            result.TypedResult.MainAccountIdObject = new AccountEntity()
            {
                Balance = 0,
                ActivityType = ActivityTypeEnum.Passive,
                CurrencyType = dto.CurrencyType,
                PrincipalId = dto.PrincipalId,
                AccountId = GetAccountNumber(dto)
            };
            result.TypedResult.PersentAccountIdObject = new AccountEntity()
            {
                Balance = 0,
                ActivityType = ActivityTypeEnum.Passive,
                CurrencyType = dto.CurrencyType,
                PrincipalId = dto.PrincipalId,
                AccountId = GetAccountNumber(dto)
            };
            return result;
        }

        public ExecutionResult CreateDepositeContract(SaveDepositContractRequest request, ExecutionContext context)
        {
            ExecutionResult<DepositContractEntity> result = context.PreviousResult as ExecutionResult<DepositContractEntity>;
            if (result == null)
                return null;
            CreditContractDto dto = request.Value as CreditContractDto;

            if (dto == null)
                return null;

            result.TypedResult.MainAccountIdObject = new AccountEntity()
            {
                Balance = 0,
                ActivityType = ActivityTypeEnum.Passive,
                CurrencyType = dto.CurrencyType,
                PrincipalId = dto.PrincipalId,
                AccountId = GetAccountNumber(dto)
            };
            result.TypedResult.PersentAccountIdObject = new AccountEntity()
            {
                Balance = 0,
                ActivityType = ActivityTypeEnum.Passive,
                CurrencyType = dto.CurrencyType,
                PrincipalId = dto.PrincipalId,
                AccountId = GetAccountNumber(dto)
            };
            return result;
        }

        private string GetAccountNumber(CreditContractDto dto)
        {
            return string.Empty;
        }

        public override int Priority => PriorityLevels.ZERO_LEVEL;
    }
}