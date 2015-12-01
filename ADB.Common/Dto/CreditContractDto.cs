using ADB.Common.Immutable;

namespace ADB.Common.Dto
{
    public class CreditContractDto: ContractDto
    {
        /// <summary>
        ///     Gets or sets the type of the credit.
        /// </summary>
        /// <value>The type of the credit.</value>
        public virtual CreditContractType CreditType { get; set; }

        /// <summary>
        ///     Gets or sets the main account identifier.
        /// </summary>
        /// <value>The main account identifier.</value>
        public virtual int MainAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the main account identifier object.
        /// </summary>
        /// <value>The main account identifier object.</value>
        public virtual string MainAccount { get; set; }

        /// <summary>
        ///     Gets or sets the percent account identifier.
        /// </summary>
        /// <value>The percent account identifier.</value>
        public virtual int PercentAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the persent account identifier object.
        /// </summary>
        /// <value>The persent account identifier object.</value>
        public virtual string PersentAccount { get; set; }

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