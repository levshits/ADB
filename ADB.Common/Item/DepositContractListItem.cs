using ADB.Common.Immutable;
using Levshits.Data.Item;

namespace ADB.Common.Item
{
    public class DepositContractListItem: BaseItem
    {
        public DepositContractType DepositType { get; set; }

        public decimal Summ { get; set; }
    }
}