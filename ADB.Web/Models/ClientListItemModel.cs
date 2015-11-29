using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ADB.Web.Attributes;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class ClientListItemModel: ModelBase
    {
        [LocalisedName()]
        public string FirstName { get; set; }
        [LocalisedName()]
        public string MiddleName { get; set; }
        [LocalisedName()]
        public string LastName { get; set; }
    }
}