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
    public class TransactionHistoryBlo: BloBase<TransactionHistoryEntity>
    {
        public const int BANK_ACCOUNT = 26;
        public const int REPOSITORY_ACCOUNT = 27;

        public AdbRepository AdbRepository => (AdbRepository) Repository;

        public TransactionHistoryBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveCreditContractRequest>(InitCreditAccount);
            RegisterCommand<SaveDepositContractRequest>(InitDepositAccount);
        }

        private ExecutionResult InitDepositAccount(SaveDepositContractRequest request, ExecutionContext context)
        {
            DepositContractDto dto = request.Value as DepositContractDto;
            if (dto == null)
            {
                return null;
            }
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int) dto.CurrencyType,
                    FromAccount = null,
                    ToAccount = REPOSITORY_ACCOUNT
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int) dto.CurrencyType,
                    FromAccount = REPOSITORY_ACCOUNT,
                    ToAccount = dto.MainAccountId
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int) dto.CurrencyType,
                    FromAccount = dto.MainAccountId,
                    ToAccount = BANK_ACCOUNT
                });
            return context.PreviousResult;
        }

        private ExecutionResult InitCreditAccount(SaveCreditContractRequest request, ExecutionContext context)
        {
            CreditContractDto dto = request.Value as CreditContractDto;
            if (dto == null)
            {
                return null;
            }
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)dto.CurrencyType,
                    FromAccount = BANK_ACCOUNT,
                    ToAccount = dto.MainAccountId
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)dto.CurrencyType,
                    FromAccount = dto.MainAccountId,
                    ToAccount = REPOSITORY_ACCOUNT
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)dto.CurrencyType,
                    FromAccount = REPOSITORY_ACCOUNT,
                    ToAccount = null
                });
            return context.PreviousResult;
        }

        public override int Priority => PriorityLevels.SECOND_LEVEL;
    }
}