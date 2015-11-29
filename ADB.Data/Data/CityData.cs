using System.Collections.Generic;
using ADB.Common.Item;
using ADB.Data.Entity;
using Levshits.Data;
using Levshits.Data.Data;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace ADB.Data.Data
{
    public class CityData: BaseData<CityEntity>
    {
        public CityData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<LookupItem> Cities()
        {
            CityEntity city = null;
            LookupItem lookupItem = null;
            var query = DataProvider.QueryOver(() => city);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => city.Id).WithAlias(() => lookupItem.Id));
            projections.Add(Projections.Property(() => city.Name).WithAlias(() => lookupItem.Value));
            projections.Add(Projections.Property(() => city.Version).WithAlias(() => lookupItem.Version));
            query.Select(projections);
            var result =
                query.TransformUsing(Transformers.AliasToBean<LookupItem>())
                    .List<LookupItem>();
            return result;

        } 
    }
}
