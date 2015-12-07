using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;


namespace ADB.Web.Models.Enumerations
{
    public enum UserTypeEnum
    {
        [Display(Name = "OrganisationUserTypeEnum", ResourceType = typeof(Localisation))]
        Organisation = 1,

        [Display(Name = "PersonUserTypeEnum", ResourceType = typeof(Localisation))]
        Person = 2,

        [Display(Name = "BusinessmanUserTypeEnum", ResourceType = typeof(Localisation))]
        Businessman = 3
    }
}