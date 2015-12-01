using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;


namespace ADB.Web.Models.Enumerations
{
    public enum Nationality
    {
        [Display(Name = "Resident", ResourceType = typeof(Localisation))]
        Resident = 300001,

        [Display(Name = "NonResident", ResourceType = typeof(Localisation))]
        NonResident = 300002
    }
}