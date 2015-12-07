using System.ComponentModel.DataAnnotations;
using ADB.Web.Attributes;
using ADB.Web.Models.Enumerations;

namespace ADB.Web.Models
{
    public class CreditContractModel : ContractModel
    {
        [Required]
        [LocalisedName()]
        public virtual CreditContractType CreditType { get; set; }

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
        ///     Gets or sets the Percent account identifier object.
        /// </summary>
        /// <value>The Percent account identifier object.</value>
        public virtual string PercentAccount { get; set; }

        [Required]
        [LocalisedName()]
        public virtual int Period { get; set; }

        [Required]
        [LocalisedName()]
        public virtual CurrencyTypeEnum CurrencyType { get; set; }

        [Required]
        [LocalisedName()]
        [DataType(DataType.Currency)]
        public virtual decimal Summ { get; set; }

        [Required]
        [LocalisedName()]
        [DataType(DataType.Currency)]
        public virtual decimal PercentValue { get; set; }
    }
}