using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Models.Enumerations
{
    public enum ActivityTypeEnum
    {
        [Display(Name = "Active", ResourceType = typeof(Localisation))]
        Active = 1,
        [Display(Name = "Passive", ResourceType = typeof(Localisation))]
        Passive = 2,
        [Display(Name = "ActivePassive", ResourceType = typeof(Localisation))]
        ActivePassive = 3
    }
}