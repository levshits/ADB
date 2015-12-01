using System.Collections.Generic;
using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    public class PrincipalEntity : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; set; }

        public virtual IList<AccountEntity> AccountEntities { get; set; }
    }
}
