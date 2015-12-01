using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class DepositContractEntityMap: SubclassMap<DepositContractEntity>
    {
        public DepositContractEntityMap()
        {
            Table("DepositContract");

            Map(x => x.DepositType);
            Map(x => x.CurrencyType);
            Map(x => x.MainAccountId);
            Map(x => x.PercentAccountId);
            Map(x => x.Period);
            Map(x => x.Summ);

            References(x => x.MainAccountIdObject).Column(nameof(DepositContractEntity.MainAccountId)).Cascade.None();
            References(x => x.PersentAccountIdObject).Column(nameof(DepositContractEntity.PercentAccountId)).Cascade.None();
        }
    }
}