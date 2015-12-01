using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    /// <summary>
    ///     Class CardEntity.
    /// </summary>
    public class CardEntity : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public virtual string Number { get; set; }

        /// <summary>
        ///     Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public virtual int ClientId { get; set; }

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public virtual int AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the client identifier object.
        /// </summary>
        /// <value>The client identifier object.</value>
        public virtual ClientEntity ClientIdObject { get; set; }

        /// <summary>
        ///     Gets or sets the account identifier object.
        /// </summary>
        /// <value>The account identifier object.</value>
        public virtual AccountEntity AccountIdObject { get; set; }
    }
}