using System.Collections.Generic;
using ADB.Common.Item;
using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Common;
using Levshits.Data.Data;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace ADB.Data.Data
{
    public class CreditContractData: BaseData<CreditContractEntity>
    {
        public CreditContractData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<CreditContractListItem> GetCredits(PagingOptions paging)
        {
            CreditContractEntity creditContractEntity = null;
            CreditContractListItem creditContractListItem = null;
            var query = DataProvider.QueryOver(() => creditContractEntity);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => creditContractEntity.Id).WithAlias(() => creditContractListItem.Id));
            projections.Add(Projections.Property(() => creditContractEntity.CreditType).WithAlias(() => creditContractListItem.CreditType));
            projections.Add(Projections.Property(() => creditContractEntity.Summ).WithAlias(() => creditContractListItem.Summ));
            AddPaging(query, paging);
            query.Select(projections);
            return query.TransformUsing(Transformers.AliasToBean<CreditContractListItem>()).List<CreditContractListItem>();
        }

        public IList<CreditContractEntity> GetAllCredits()
        {
            CreditContractEntity creditContractEntity = null;
            var query = DataProvider.QueryOver(() => creditContractEntity);
            return query.List();
        }
    }
}