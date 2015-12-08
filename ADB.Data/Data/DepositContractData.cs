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
    public class DepositContractData: BaseData<DepositContractEntity>
    {
        public DepositContractData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        /// <summary>
        /// Gets the deposits.
        /// </summary>
        /// <param name="paging">The paging.</param>
        /// <returns>IList&lt;DepositContractListItem&gt;.</returns>
        public IList<DepositContractListItem> GetDeposits(PagingOptions paging)
        {
            DepositContractEntity depositContractEntity = null;
            DepositContractListItem depositContractListItem = null;
            var query = DataProvider.QueryOver(() => depositContractEntity);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => depositContractEntity.Id).WithAlias(() => depositContractListItem.Id));
            projections.Add(Projections.Property(() => depositContractEntity.DepositType).WithAlias(() => depositContractListItem.DepositType));
            projections.Add(Projections.Property(() => depositContractEntity.Summ).WithAlias(() => depositContractListItem.Summ));
            AddPaging(query, paging);
            query.Select(projections);
            return query.TransformUsing(Transformers.AliasToBean<DepositContractListItem>()).List<DepositContractListItem>();
        }

        public IList<DepositContractEntity> GetAllDeposits()
        {
            DepositContractEntity depositContractEntity = null;
            var query = DataProvider.QueryOver(() => depositContractEntity);
            return query.List();
        }
    }
}