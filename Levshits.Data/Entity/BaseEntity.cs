using System;

namespace Levshits.Data.Entity
{
    /// <summary>
    /// Class EntityBase.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public virtual int Version { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the modify time.
        /// </summary>
        /// <value>The modify time.</value>
        public virtual  DateTime ModifyTime { get; set; }
    }
}
