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
            Map(x => x.MiddleName);
            Map(x => x.LastName);
            Map(x => x.BirthDate);
            Map(x => x.PassportSeries);
            Map(x => x.PassportNumber);
            Map(x => x.PassportId);
            Map(x => x.IssuedBy);
            Map(x => x.IssuedDate);
            Map(x => x.BirthPlace);
            Map(x => x.ResidenceCityId);
            Map(x => x.ResidenceAddress);
            Map(x => x.RegistrationAddress);
            Map(x => x.MaritalStatus);
            Map(x => x.Nationality);
            Map(x => x.DisabilityStatus);
            Map(x => x.MonthlyIncome);
            Map(x => x.IsRetired);

            Map(x => x.HomePhone).Nullable();
            Map(x => x.MobilePhone).Nullable();
            Map(x => x.Email).Nullable();
            Map(x => x.Company).Nullable();
            Map(x => x.Position).Nullable();

            References(v => v.ResidenceCity).Column("ResidenceCityId").ReadOnly();

        }
    }
}
