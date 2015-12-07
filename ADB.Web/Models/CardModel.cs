using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ADB.Common.Item;
using ADB.Web.Attributes;

namespace ADB.Web.Models
{
    public class CardModel: CardFirstStepModel
    {
        [Required]
        [LocalisedName()]
        public int AccountId { get; set; }

        public IList<LookupItem> AccountLookupItems { get; set; }
    }
}