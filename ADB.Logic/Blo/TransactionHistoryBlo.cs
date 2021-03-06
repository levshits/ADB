﻿using System;
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
        public const int BANK_ACCOUNT_BYR = 26;
        public const int REPOSITORY_ACCOUNT_BYR = 27;
        public const int BANK_ACCOUNT_USD = 47;
        public const int REPOSITORY_ACCOUNT_USD = 49;
        public const int BANK_ACCOUNT_EUR = 48;
        public const int REPOSITORY_ACCOUNT_EUR = 51;

        public AdbRepository AdbRepository => (AdbRepository) Repository;

        public TransactionHistoryBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<SaveCreditContractRequest>(InitCreditAccount);
            RegisterCommand<SaveDepositContractRequest>(InitDepositAccount);
            RegisterCommand<CashRequest>(GetCash);
        }

        private ExecutionResult GetCash(CashRequest request, ExecutionContext context)
        {
            var account = AdbRepository.AccountData.GetEntityById(request.AccountId);
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = request.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)account.CurrencyType,
                    FromAccount = account.Id,
                    ToAccount = GetRepositoryAccount((CurrencyTypeEnum)account.CurrencyType)
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = request.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)account.CurrencyType,
                    FromAccount = GetRepositoryAccount((CurrencyTypeEnum)account.CurrencyType),
                    ToAccount = null
                });
            return context.PreviousResult;
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
                    ToAccount = GetRepositoryAccount(dto.CurrencyType)
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int) dto.CurrencyType,
                    FromAccount = GetRepositoryAccount(dto.CurrencyType),
                    ToAccount = dto.MainAccountId
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int) dto.CurrencyType,
                    FromAccount = dto.MainAccountId,
                    ToAccount = GetBankAccount(dto.CurrencyType)
                });
            AccountEntity account = AdbRepository.AccountData.GetEntityById(GetBankAccount(dto.CurrencyType));
            account.Balance += dto.Summ;
            AdbRepository.AccountData.Save(account);
            return context.PreviousResult;
        }

        public static int GetRepositoryAccount(CurrencyTypeEnum currencyType)
        {
            switch (currencyType)
            {
                case CurrencyTypeEnum.BYR:
                    return REPOSITORY_ACCOUNT_BYR;
                case CurrencyTypeEnum.EUR:
                    return REPOSITORY_ACCOUNT_EUR;
                case CurrencyTypeEnum.USD:
                    return REPOSITORY_ACCOUNT_USD;
            }
            return REPOSITORY_ACCOUNT_BYR;
        }

        public static int GetBankAccount(CurrencyTypeEnum currencyType)
        {
            switch (currencyType)
            {
                case CurrencyTypeEnum.BYR:
                    return BANK_ACCOUNT_BYR;
                case CurrencyTypeEnum.EUR:
                    return BANK_ACCOUNT_EUR;
                case CurrencyTypeEnum.USD:
                    return BANK_ACCOUNT_USD;
            }
            return REPOSITORY_ACCOUNT_BYR;
        }

        private ExecutionResult InitCreditAccount(SaveCreditContractRequest request, ExecutionContext context)
        {
            CreditContractDto dto = request.Value as CreditContractDto;
            if (dto == null)
            {
                return null;
            }

            AccountEntity account = AdbRepository.AccountData.GetEntityById(GetBankAccount(dto.CurrencyType));
            account.Balance -= dto.Summ;
            AdbRepository.AccountData.Save(account);

            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)dto.CurrencyType,
                    FromAccount = GetBankAccount(dto.CurrencyType),
                    ToAccount = dto.MainAccountId
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)dto.CurrencyType,
                    FromAccount = dto.MainAccountId,
                    ToAccount = GetRepositoryAccount(dto.CurrencyType)
                });
            AdbRepository.TransactionHistoryData.Save(
                new TransactionHistoryEntity()
                {
                    Count = dto.Summ,
                    CreateTime = DateTime.Now,
                    CurrencyType = (int)dto.CurrencyType,
                    FromAccount = GetRepositoryAccount(dto.CurrencyType),
                    ToAccount = null
                });
            return context.PreviousResult;
        }

        public override int Priority => PriorityLevels.SECOND_LEVEL;
    }
}