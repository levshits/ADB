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

        private ExecutionResult CloseDayHandler(CloseDayRequest request, ExecutionContext context)
        {
            ExecutionResult<List<string>> result = context.PreviousResult as ExecutionResult<List<string>>;
            result = result ?? new ExecutionResult<List<string>> {TypedResult = new List<string>()};
            var operations = new List<string>();
            var credits = AdbRepository.CreditContractData.GetAllCredits();
            foreach (var credit in credits)
            {
                DateTime lastProcessingTime = credit.ProcessingTime ?? credit.AssignDate;
                TimeSpan delta = (DateTime)request.Value - lastProcessingTime;
                if (delta.Days >= 30 && ((DateTime)request.Value - credit.AssignDate).Days < 30 * credit.Period)
                {
                    switch ((CreditContractType)credit.CreditType)
                    {
                        case CreditContractType.CreditType1:
                            {
                                decimal percent = (credit.PercentValue / 365 * delta.Days);
                                decimal v = (decimal) Math.Pow(((double) (1 + percent)), credit.Period);
                                decimal summ = credit.Summ*percent*v/(v-1); 
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = credit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount = null,
                                    ToAccount = TransactionHistoryBlo.GetRepositoryAccount((CurrencyTypeEnum)credit.CurrencyType)
                                });
                                operations.Add($"{DateTime.Now} Оплата по кредиту №{credit.Id} внесена в кассу");
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = credit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount = credit.PercentAccountId,
                                    ToAccount = TransactionHistoryBlo.GetRepositoryAccount((CurrencyTypeEnum)credit.CurrencyType)
                                });
                                operations.Add($"{DateTime.Now} Оплата по кредиту №{credit.Id}  зачислена на счет {credit.PercentAccountIdObject.AccountId}");
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = credit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount = credit.PercentAccountId,
                                    ToAccount = TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum)credit.CurrencyType)
                                });

                                var bankAccount = AdbRepository.AccountData.GetEntityById(TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum)credit.CurrencyType));
                                bankAccount.Balance += summ;
                                AdbRepository.AccountData.Save(bankAccount);
                                operations.Add($"{DateTime.Now} Оплата по кредиту №{credit.Id}  зачислена на счет банка {bankAccount.AccountId}");
                                
                                
                            }
                            break;
                        case CreditContractType.CreditType2:
                            {
                                decimal summ = credit.PercentValue / 365 * delta.Days/100*credit.Summ;
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = credit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount = null,
                                    ToAccount = TransactionHistoryBlo.GetRepositoryAccount((CurrencyTypeEnum)credit.CurrencyType)
                                });
                                operations.Add($"{DateTime.Now} Процент по кредиту №{credit.Id} внесен в кассу");
                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = credit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount = TransactionHistoryBlo.GetRepositoryAccount((CurrencyTypeEnum)credit.CurrencyType),
                                    ToAccount = credit.PercentAccountId
                                });
                                operations.Add($"{DateTime.Now} Процент по кредиту №{credit.Id} переведен на процентный счет клиента {credit.PercentAccountIdObject.AccountId}");

                                AdbRepository.TransactionHistoryData.Save(new TransactionHistoryEntity
                                {
                                    Count = summ,
                                    CurrencyType = credit.CurrencyType,
                                    CreateTime = DateTime.Now,
                                    FromAccount = credit.PercentAccountId,
                                    ToAccount = TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum)credit.CurrencyType)
                                });
                                operations.Add($"{DateTime.Now} Процент по кредиту №{credit.Id} погашен");

                                var bankAccount = AdbRepository.AccountData.GetEntityById(TransactionHistoryBlo.GetBankAccount((CurrencyTypeEnum)credit.CurrencyType));
                                bankAccount.Balance += summ;
                                AdbRepository.AccountData.Save(bankAccount);
                                operations.Add($"{DateTime.Now} Оплата по кредиту №{credit.Id}  зачислена на счет банка {bankAccount.AccountId}");
                            }
                            break;
                    }
                    credit.ProcessingTime = DateTime.Now;
                    AdbRepository.CreditContractData.Save(credit);
                }
                if (((DateTime)request.Value - credit.AssignDate).Days == 30 * credit.Period)
                {
                    if (credit.CreditType == (int) CreditContractType.CreditType2)
                    {
                        if (((DateTime)request.Value - deposit.AssignDate).Days == 30 * deposit.Period)
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
                        operations.Add($"{DateTime.Now} Кредит №{credit.Id} закрыт");
                    }
                }
            }
            result.TypedResult.AddRange(operations);
            return result;
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