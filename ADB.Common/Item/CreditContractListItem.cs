using ADB.Common.Immutable;
using Levshits.Data.Item;

namespace ADB.Common.Item
{
    public class CreditContractListItem : BaseItem
    {
        public CreditContractType CreditType { get; set; }
        public decimal Summ { get; set; }
    }
}