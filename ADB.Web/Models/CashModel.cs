using System.ComponentModel.DataAnnotations;
using ADB.Web.Models.Enumerations;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class CashModel: ModelBase
    {
        [Required]
        public decimal Value { get; set; }
        public CurrencyTypeEnum CurrencyType { get; set; }
    }
}