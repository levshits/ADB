using System;
using ADB.Common.Dto;
using ADB.Common.Immutable;
using ADB.Common.Requests;
using ADB.Data.Common;
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

        public AdbRepository AdbRepository => (AdbRepository) Repository;

        public ExecutionResult CreateCreditContract(SaveCreditContractRequest request, ExecutionContext context)
        {
            ExecutionResult<CreditContractEntity> result = context.PreviousResult as ExecutionResult<CreditContractEntity>;
            result = result ?? new ExecutionResult<CreditContractEntity>();
            CreditContractDto dto = request.Value as CreditContractDto;

            if (dto == null)
                return null;

            var mainAccount = new AccountEntity()
            {
                Balance = 0,
                ActivityType = (int) ActivityTypeEnum.Passive,
                CurrencyType = (int) dto.CurrencyType,
                OwnerId = dto.PrincipalId,
                AccountId = String.Empty
            };

            var mainAccountId = (int)AdbRepository.AccountData.Save(mainAccount);
            mainAccount.AccountId = $"3014{mainAccountId:000000000}";
            AdbRepository.AccountData.Save(mainAccount);

            var PercentAccount = new AccountEntity()
            {
                Balance = 0,
                ActivityType = (int) ActivityTypeEnum.Passive,
                CurrencyType = (int) dto.CurrencyType,
                OwnerId = dto.PrincipalId,
                AccountId = string.Empty
            };
            var PercentAccountId = (int)AdbRepository.AccountData.Save(PercentAccount);
            PercentAccount.AccountId = $"3014{PercentAccountId:000000000}";
            AdbRepository.AccountData.Save(PercentAccount);

            dto.MainAccountId = mainAccountId;
            dto.PercentAccountId = PercentAccountId;
            return result;
        }

        public ExecutionResult CreateDepositeContract(SaveDepositContractRequest request, ExecutionContext context)
        {
            ExecutionResult<DepositContractEntity> result = context.PreviousResult as ExecutionResult<DepositContractEntity>;
            result = result ?? new ExecutionResult<DepositContractEntity>();
            DepositContractDto dto = request.Value as DepositContractDto;

            if (dto == null)
                return null;

            var mainAccount = new AccountEntity()
            {
                Balance = 0,
                ActivityType = (int) ActivityTypeEnum.Passive,
                CurrencyType = (int) dto.CurrencyType,
                OwnerId = dto.PrincipalId,
                AccountId = String.Empty
            };

            var mainAccountId = (int)AdbRepository.AccountData.Save(mainAccount);
            mainAccount.AccountId = $"3014{mainAccountId:000000000}";
            AdbRepository.AccountData.Save(mainAccount);

            var PercentAccount = new AccountEntity()
            {
                Balance = 0,
                ActivityType = (int) ActivityTypeEnum.Passive,
                CurrencyType = (int) dto.CurrencyType,
                OwnerId = dto.PrincipalId,
                AccountId = string.Empty
            };
            var PercentAccountId = (int)AdbRepository.AccountData.Save(PercentAccount);
            PercentAccount.AccountId = $"3014{PercentAccountId:000000000}";
            AdbRepository.AccountData.Save(PercentAccount);

            dto.MainAccountId = mainAccountId;
            dto.PercentAccountId = PercentAccountId;
            return result;
        }
        public override int Priority => PriorityLevels.ZERO_LEVEL;
    }
}