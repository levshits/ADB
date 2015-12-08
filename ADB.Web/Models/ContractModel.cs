using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ADB.Common.Item;
using ADB.Web.Attributes;
using ADB.Web.Models.Enumerations;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class ContractModel: ModelBase
    {
        [Required]
        [LocalisedName()]
        [DataType(DataType.Date)]
        public DateTime AssignDate { get; set; } = DateTime.Today;

        [Required]
        [LocalisedName()]
        public int PrincipalId { get; set; }

        [LocalisedName()]
        public string PrincipalName { get; set; }

        public IList<LookupItem> ClientsLookupItems { get; set; }
        public ContractTypeEnum ContractType { get; set; }
    }
}