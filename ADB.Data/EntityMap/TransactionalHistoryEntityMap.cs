using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class TransactionalHistoryEntityMap: ClassMap<TransactionHistoryEntity>
    {
        public TransactionalHistoryEntityMap()
        {
            Table("TransactionHistory");
            Id(x => x.Id);
            Version(x => x.Version);
            Map(x => x.CreateTime);
            Map(x => x.Count);
            Map(x => x.ToAccountId);
            Map(x => x.FromAccountId);
            Map(x => x.CurrencyType);

            References(v => v.ToAccountIdObject).Column(nameof(TransactionHistoryEntity.ToAccountId));
            References(v => v.FromAccountIdObject).Column(nameof(TransactionHistoryEntity.FromAccountId));
        }
    }
}