using ADB.Common.Immutable;
using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    /// <summary>
    ///     Class AccountEntity.
    /// </summary>
    public class AccountEntity : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the principal identifier object.
        /// </summary>
        /// <value>The principal identifier object.</value>
        public virtual PrincipalEntity PrincipalIdObject { get; set; }

        /// <summary>
        ///     Gets or sets the principal identifier.
        /// </summary>
        /// <value>The principal identifier.</value>
        public virtual int PrincipalId { get; set; }

        /// <summary>
        ///     Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public virtual decimal Balance { get; set; }

        /// <summary>
        ///     Gets or sets the type of the currency.
        /// </summary>
        /// <value>The type of the currency.</value>
        public virtual CurrencyTypeEnum CurrencyType { get; set; }

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public virtual string AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        public virtual UserTypeEnum UserType { get; set; }

        /// <summary>
        ///     Gets or sets the type of the activity.
        /// </summary>
        /// <value>The type of the activity.</value>
        public virtual ActivityTypeEnum ActivityType { get; set; }
    }
}