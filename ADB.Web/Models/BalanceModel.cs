using ADB.Web.Models.Enumerations;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class BalanceModel: ModelBase
    {
        public decimal Value { get; set; }
        public CurrencyTypeEnum CurrencyType { get; set; }
    }
}