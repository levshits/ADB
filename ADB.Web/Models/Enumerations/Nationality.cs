using System.ComponentModel.DataAnnotations;
using ADB.Web.Attributes;

namespace ADB.Web.Models.Enumerations
{
    public enum Nationality
    {
        [LocalisedName()]
        Resident = 300001,
        [LocalisedName()]
        NonResident = 300002
    }
}