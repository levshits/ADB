using System.Collections.Generic;
using ADB.Common.Item;
using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace ADB.Data.Data
{
    public class AccountData: BaseData<AccountEntity>
    {
        public AccountData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<LookupItem> Accounts(int value)
        {
            AccountEntity city = null;
            LookupItem lookupItem = null;
            var query = DataProvider.QueryOver(() => city);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => city.Id).WithAlias(() => lookupItem.Id));
            projections.Add(Projections.Property(() => city.AccountId).WithAlias(() => lookupItem.Value));
            query.Where(x => x.OwnerId == value);
            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<LookupItem>())
                    .List<LookupItem>();
            return result;
        }
    }
}