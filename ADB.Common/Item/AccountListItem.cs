using ADB.Common.Immutable;

namespace ADB.Common.Item
{
    public class AccountListItem
    {
        public string AccountNumber { get; set; }
        public ActivityTypeEnum ActivityType { get; set; }
        public decimal Balance { get; set; }
    }
}