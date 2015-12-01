using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class PrincipalEntityMap: ClassMap<PrincipalEntity>
    {
        public PrincipalEntityMap()
        {
            Table("Principal");
            Id(x => x.Id);
            Version(x => x.Version);
            Map(x => x.Name).Length(600);
        }    
    }
}