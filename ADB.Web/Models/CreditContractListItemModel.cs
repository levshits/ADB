﻿using ADB.Web.Attributes;
using ADB.Web.Models.Enumerations;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class CreditContractListItemModel : ModelBase
    {
        [LocalisedName()]
        public CreditContractType CreditType { get; set; }

        [LocalisedName()]
        public decimal Summ { get; set; }
    }
}