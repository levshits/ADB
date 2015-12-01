using ADB.Common.Immutable;

namespace ADB.Data.Entity
{
    /// <summary>
    ///     Class DepositContractEntity.
    /// </summary>
    public class DepositContractEntity : ContractEntity
    {
        /// <summary>
        ///     Gets or sets the type of the deposit.
        /// </summary>
        /// <value>The type of the deposit.</value>
        public virtual DepositContractType DepositType { get; set; }

        /// <summary>
        ///     Gets or sets the main account identifier.
        /// </summary>
        /// <value>The main account identifier.</value>
        public virtual int MainAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the main account identifier object.
        /// </summary>
        /// <value>The main account identifier object.</value>
        public virtual AccountEntity MainAccountIdObject { get; set; }

        /// <summary>
        ///     Gets or sets the percent account identifier.
        /// </summary>
        /// <value>The percent account identifier.</value>
        public virtual int PercentAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the persent account identifier object.
        /// </summary>
        /// <value>The persent account identifier object.</value>
        public virtual AccountEntity PersentAccountIdObject { get; set; }

        /// <summary>
        ///     Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        public virtual int Period { get; set; }

        /// <summary>
        ///     Gets or sets the type of the currency.
        /// </summary>
        /// <value>The type of the currency.</value>
        public virtual CurrencyTypeEnum CurrencyType { get; set; }

        /// <summary>
        ///     Gets or sets the summ.
        /// </summary>
        /// <value>The summ.</value>
        public virtual decimal Summ { get; set; }
    }
}