using ADB.Data.Entity;
using FluentNHibernate.Mapping;
using Levshits.Data.Entity;

namespace ADB.Data.EntityMap
{
    public class CreditContractEntityMap: SubclassMap<CreditContractEntity>
    {
        public CreditContractEntityMap()
        {
            KeyColumn(nameof(BaseEntity.Id));
            Table("CreditContract");

            Map(x => x.CreditType);
            Map(x => x.CurrencyType);
            Map(x => x.MainAccountId);
            Map(x => x.PercentAccountId);
            Map(x => x.Period);
            Map(x => x.Summ);
            Map(x => x.PercentValue);

            References(x => x.MainAccountIdObject).Column(nameof(CreditContractEntity.MainAccountId)).Cascade.None().ReadOnly();
            References(x => x.PercentAccountIdObject).Column(nameof(CreditContractEntity.PercentAccountId)).Cascade.None().ReadOnly();
        }
         
    }
}