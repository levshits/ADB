using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    public class ClientEntity: BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
