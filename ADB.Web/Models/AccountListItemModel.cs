using ADB.Web.Attributes;
using ADB.Web.Models.Enumerations;

namespace ADB.Web.Models
{
    public class AccountListItemModel
    {
        [LocalisedName]
        public string AccountNumber { get; set; }
        [LocalisedName]
        public ActivityTypeEnum ActivityType  { get; set; }
        [LocalisedName]
        public decimal Balance { get; set; }
    }
}