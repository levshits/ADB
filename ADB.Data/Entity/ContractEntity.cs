using System;
using ADB.Common.Immutable;
using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    /// <summary>
    /// Class ContractEntity.
    /// </summary>
    public class ContractEntity: BaseEntity
    {
        /// <summary>
        /// Gets or sets the assign date.
        /// </summary>
        /// <value>The assign date.</value>
        public virtual DateTime AssignDate { get; set; }
        /// <summary>
        /// Gets or sets the principal identifier.
        /// </summary>
        /// <value>The principal identifier.</value>
        public virtual int PrincipalId { get; set; }
        /// <summary>
        /// Gets or sets the principal identifier object.
        /// </summary>
        /// <value>The principal identifier object.</value>
        public virtual PrincipalEntity PrincipalIdObject { get; set; }
        /// <summary>
        /// Gets or sets the type of the contract.
        /// </summary>
        /// <value>The type of the contract.</value>
        public virtual int ContractType { get; set; }
    }
}