using System;
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
            RegisterCommand<CloseDayRequest>(CloseDayHandler);
        }

        private ExecutionResult CloseDayHandler(CloseDayRequest request, ExecutionContext context)
        {
            ExecutionResult<List<string>> result = context.PreviousResult as ExecutionResult<List<string>>;
            result = result ?? new ExecutionResult<List<string>> { TypedResult = new List<string>() };
            var operations = new List<string>();
            var deposits = AdbRepository.DepositContractData.GetAllDeposits();
            foreach (var deposit in deposits)
            {
                DateTime lastProcessingTime = deposit.ProcessingTime ?? deposit.AssignDate;
                TimeSpan delta = (DateTime)request.Value - lastProcessingTime;
                if (delta.Days >= 30 && (deposit.AssignDate - (DateTime)request.Value).Days < 30*deposit.Period)
                {
                    decimal summ = deposit.PercentValue/365*delta.Days/100*deposit.Summ;
                    switch ((DepositContractType) deposit.DepositType)
                    {
                        case DepositContractType.DepositType1:
                        {
                            AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                            {
                                Count = summ,
                                CurrencyType = deposit.CurrencyType,
                                CreateTime = DateTime.Now,
                                FromAccount =
                                    TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum) deposit.CurrencyType),
                                ToAccount = deposit.PercentAccountId
                            });
                                operations.Add($"{DateTime.Now} Процент по депозиту №{deposit.Id} переведен на счет {deposit.PercentAccountIdObject.AccountId}");
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                            {
                                Count = summ,
                                CurrencyType = deposit.CurrencyType,
                                CreateTime = DateTime.Now,
                                FromAccount = deposit.PercentAccountId,
                                ToAccount = TransactionHistoryBlo.GetRepositoryAccount((CurrencyTypeEnum)deposit.CurrencyType)
                            });
                                operations.Add($"{DateTime.Now} Процент по депозиту №{deposit.Id}  получен в кассе");
                            }
                            break;
                        case DepositContractType.DepositType2:
                        {
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = deposit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount =
            TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum)deposit.CurrencyType),
                                    ToAccount = deposit.PercentAccountId
                                });
                            operations.Add($"{DateTime.Now} Процент по депозиту №{deposit.Id} переведен на счет {deposit.PercentAccountIdObject.AccountId}");
                            var percentAccount = AdbRepository.AccountData.GetEntityById(deposit.PercentAccountId);
                            percentAccount.Balance += summ;
                            AdbRepository.AccountData.Save(percentAccount);
                        }
                            break;
                    }
                    deposit.ProcessingTime = DateTime.Now;
                    AdbRepository.DepositContractData.Save(deposit);
                }
                if (((DateTime)request.Value - deposit.AssignDate).Days == 30*deposit.Period)
                {
                    AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                    {
                        Count = deposit.Summ,
                        CurrencyType = deposit.CurrencyType,
                        CreateTime = DateTime.Now,
                        FromAccount =
            TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum)deposit.CurrencyType),
                        ToAccount = deposit.MainAccountId
                    });
                    operations.Add($"{DateTime.Now} Депозит №{deposit.Id} закрыт");
                }
            }
            result.TypedResult.AddRange(operations);
            return result;
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
            entity.ContractType = (int)ContractTypeEnum.DepositContract;
            AdbRepository.DepositContractData.Save(entity);
            return new ExecutionResult();
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}