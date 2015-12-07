using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class AccountEntityMap: ClassMap<AccountEntity>
    {
        public AccountEntityMap()
        {
            Table("Account");
            Id(x => x.Id);
            Version(x => x.Version);

            Map(x => x.AccountId);
            Map(x => x.ActivityType);
            Map(x => x.Balance);
            Map(x => x.CurrencyType);
            Map(x => x.UserType);
            Map(x => x.OwnerId);

            References(x => x.OwnerIdObject).Column(nameof(AccountEntity.OwnerId)).ReadOnly();
        }
    }
}