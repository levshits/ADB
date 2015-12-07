using ADB.Data.Entity;
using FluentNHibernate.Mapping;
using Levshits.Data.Entity;

namespace ADB.Data.EntityMap
{
    public class DepositContractEntityMap: SubclassMap<DepositContractEntity>
    {
        public DepositContractEntityMap()
        {
            KeyColumn(nameof(BaseEntity.Id));
            Table("DepositContract");

            Map(x => x.DepositType);
            Map(x => x.CurrencyType);
            Map(x => x.MainAccountId);
            Map(x => x.PercentAccountId);
            Map(x => x.Period);
            Map(x => x.Summ);
            Map(x => x.PercentValue);

            References(x => x.MainAccountIdObject).Column(nameof(DepositContractEntity.MainAccountId)).ReadOnly();
            References(x => x.PercentAccountIdObject).Column(nameof(DepositContractEntity.PercentAccountId)).ReadOnly();
        }
    }
}