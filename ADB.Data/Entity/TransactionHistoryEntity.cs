using System;
using ADB.Common.Immutable;
using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    /// <summary>
    ///     Class TransactionHistoryEntity.
    /// </summary>
    public class TransactionHistoryEntity : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the type of the currency.
        /// </summary>
        /// <value>The type of the currency.</value>
        public virtual CurrencyTypeEnum CurrencyType { get; set; }

        /// <summary>
        ///     Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        ///     Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public virtual decimal Count { get; set; }

        /// <summary>
        ///     Gets or sets from account identifier.
        /// </summary>
        /// <value>From account identifier.</value>
        public virtual int FromAccountId { get; set; }

        /// <summary>
        ///     Gets or sets from account identifier object.
        /// </summary>
        /// <value>From account identifier object.</value>
        public virtual AccountEntity FromAccountIdObject { get; set; }

        /// <summary>
        ///     Gets or sets to account identifier.
        /// </summary>
        /// <value>To account identifier.</value>
        public virtual int ToAccountId { get; set; }

        /// <summary>
        ///     Gets or sets to account identifier object.
        /// </summary>
        /// <value>To account identifier object.</value>
        public virtual AccountEntity ToAccountIdObject { get; set; }
    }
}