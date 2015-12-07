using ADB.Web.Attributes;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class CardListItemModel: ModelBase
    {
        [LocalisedName()]
        public string Number { get; set; }

        [LocalisedName()]
        public string PrincipalName { get; set; }

        [LocalisedName()]
        public string AccountId { get; set; }
    }
}