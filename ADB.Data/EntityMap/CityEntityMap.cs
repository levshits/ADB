using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class CityEntityMap: ClassMap<CityEntity>
    {
        public CityEntityMap()
        {
            Table("City");
            Id(v => v.Id);
            Version(v => v.Version);
            Map(v => v.Name);
        }
    }
}