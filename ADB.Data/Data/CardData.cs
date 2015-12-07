using System.Collections.Generic;
using ADB.Common.Item;
using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Common;
using Levshits.Data.Data;
using Levshits.Logic.Common;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;

namespace ADB.Data.Data
{
    public class CardData: BaseData<CardEntity>
    {
        public CardData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<CardListItem> Cards(PagingOptions paging)
        {
            CardEntity creditContractEntity = null;
            CardListItem creditContractListItem = null;
            AccountEntity accountEntity = null;
            PrincipalEntity principalEntity = null;
            var query = DataProvider.QueryOver(() => creditContractEntity);
            var accountQuery = query.JoinAlias(x => x.AccountIdObject, () => accountEntity, JoinType.InnerJoin);
            var principalQuery = query.JoinAlias(x => x.ClientIdObject, () => principalEntity, JoinType.InnerJoin);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => creditContractEntity.Number).WithAlias(() => creditContractListItem.Number));
            projections.Add(Projections.Property(() => accountEntity.AccountId).WithAlias(() => accountEntity.AccountId));
            projections.Add(Projections.Property(() => principalEntity.Name).WithAlias(() => creditContractListItem.PrincipalName));
            AddPaging(query, paging);
            query.Select(projections);
            return query.TransformUsing(Transformers.AliasToBean<CardListItem>()).List<CardListItem>();

        }
    }
}