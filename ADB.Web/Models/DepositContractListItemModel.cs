using ADB.Web.Attributes;
using ADB.Web.Models.Enumerations;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class DepositContractListItemModel: ModelBase
    {
        [LocalisedName()]
        public DepositContractType DepositType { get; set; }

        [LocalisedName()]
        public decimal Summ { get; set; }
    }
}