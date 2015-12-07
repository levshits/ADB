using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ADB.Common.Item;
using ADB.Web.Attributes;

namespace ADB.Web.Models
{
    public class CardFirstStepModel
    {
        [Required]
        [LocalisedName()]
        public int ClientId { get; set; }

        public IList<LookupItem> ClientsLookupItems { get; set; }
    }
}