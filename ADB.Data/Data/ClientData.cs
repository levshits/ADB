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
    public class ClientData: BaseData<ClientEntity>
    {
        public ClientData(DataProvider dataProvider) : base(dataProvider)
        {
        }

        public IList<ClientListItem> GetClients(PagingOptions paging)
        {
            ClientEntity client = null;
            ClientListItem clientListItem = null;
            var query = DataProvider.QueryOver(() => client);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => client.Id).WithAlias(()=>clientListItem.Id));
            projections.Add(Projections.Property(() => client.FirstName).WithAlias(() => clientListItem.FirstName));
            projections.Add(Projections.Property(() => client.LastName).WithAlias(() => clientListItem.LastName));
            projections.Add(Projections.Property(() => client.MiddleName).WithAlias(() => clientListItem.MiddleName));
            projections.Add(Projections.Property(() => client.Version).WithAlias(() => clientListItem.Version));
            AddPaging(query, paging);
            query.Select(projections);
            return query.TransformUsing(Transformers.AliasToBean<ClientListItem>()).List<ClientListItem>();
        }

        public IList<LookupItem> GetClientsLookup()
        {
            ClientEntity client = null;
            LookupItem clientListItem = null;
            var query = DataProvider.QueryOver(() => client);
            var projections = Projections.ProjectionList();
            projections.Add(Projections.Property(() => client.Id).WithAlias(() => clientListItem.Id));
            projections.Add(Projections.Property(() => client.Name).WithAlias(() => clientListItem.Value));
            query.Select(projections);
            return query.TransformUsing(Transformers.AliasToBean<LookupItem>()).List<LookupItem>();
        }
    }
}