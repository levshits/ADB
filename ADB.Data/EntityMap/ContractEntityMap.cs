using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class ContractEntityMap: ClassMap<ContractEntity>
    {
        public ContractEntityMap()
        {
            Id(x => x.Id);
            Map(x => x.AssignDate);
            Map(x => x.ContractType);
            Map(x => x.PrincipalId);

            References(x => x.PrincipalIdObject).Column(nameof(ContractEntity.PrincipalId)).ReadOnly();
        }
    }
}