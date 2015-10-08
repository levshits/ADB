using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class ClientEntityMap: ClassMap<ClientEntity>
    {
        public ClientEntityMap()
        {
            Table("Client");
            Id(x => x.Id);
            Version(x => x.Version);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}
