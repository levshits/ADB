using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class CreditContractEntityMap: SubclassMap<CreditContractEntity>
    {
        public CreditContractEntityMap()
        {
            Table("CreditContract");

            Map(x => x.CreditType);
            Map(x => x.CurrencyType);
            Map(x => x.MainAccountId);
            Map(x => x.PercentAccountId);
            Map(x => x.Period);
            Map(x => x.Summ);

            References(x => x.MainAccountIdObject).Column(nameof(CreditContractEntity.MainAccountId)).Cascade.None();
            References(x => x.PersentAccountIdObject).Column(nameof(CreditContractEntity.PercentAccountId)).Cascade.None();
        }
         
    }
}