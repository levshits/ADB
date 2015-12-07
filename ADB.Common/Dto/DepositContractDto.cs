using ADB.Common.Immutable;

namespace ADB.Common.Dto
{
    public class DepositContractDto: ContractDto
    {
        /// <summary>
        ///     Gets or sets the type of the credit.
        /// </summary>
        /// <value>The type of the credit.</value>
        public DepositContractType DepositType { get; set; }

        /// <summary>
        ///     Gets or sets the main account identifier.
        /// </summary>
        /// <value>The main account identifier.</value>
        public int MainAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the main account identifier object.
        /// </summary>
        /// <value>The main account identifier object.</value>
        public string MainAccount { get; set; }

        /// <summary>
        ///     Gets or sets the percent account identifier.
        /// </summary>
        /// <value>The percent account identifier.</value>
        public int PercentAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the Percent account identifier object.
        /// </summary>
        /// <value>The Percent account identifier object.</value>
        public string PercentAccount { get; set; }

        public decimal PercentValue { get; set; }

        /// <summary>
        ///     Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        public int Period { get; set; }

        /// <summary>
        ///     Gets or sets the type of the currency.
        /// </summary>
        /// <value>The type of the currency.</value>
        public CurrencyTypeEnum CurrencyType { get; set; }

        /// <summary>
        ///     Gets or sets the summ.
        /// </summary>
        /// <value>The summ.</value>
        public decimal Summ { get; set; }
    }
}