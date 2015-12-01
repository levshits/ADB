using ADB.Data.Entity;
using FluentNHibernate.Mapping;

namespace ADB.Data.EntityMap
{
    public class CardEntityMap: ClassMap<CardEntity>
    {
        public CardEntityMap()
        {
            Id(x => x.Id);
            Map(x => x.Number).Length(16);
            Map(x => x.AccountId);
            Map(x => x.ClientId);

            References(x => x.AccountIdObject).Column(nameof(CardEntity.AccountId)).ReadOnly();
            References(x => x.ClientIdObject).Column(nameof(CardEntity.ClientId)).ReadOnly();
        }    
    }
}