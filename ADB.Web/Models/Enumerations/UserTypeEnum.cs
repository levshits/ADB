using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;


namespace ADB.Web.Models.Enumerations
{
    public enum UserTypeEnum
    {
        [Display(Name = "OrganisationUserTypeEnum", ResourceType = typeof(Localisation))]
        Organisation,

        [Display(Name = "PersonUserTypeEnum", ResourceType = typeof(Localisation))]
        Person,

        [Display(Name = "BusinessmanUserTypeEnum", ResourceType = typeof(Localisation))]
        Businessman
    }
}