using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;


namespace ADB.Web.Models.Enumerations
{
    public enum DisabilityStatus
    {
        [Display(Name = "None", ResourceType = typeof(Localisation))]
        None =200000,

        [Display(Name = "FirstLevel", ResourceType = typeof(Localisation))]
        FirstLevel =200001,

        [Display(Name = "SecondLevel", ResourceType = typeof(Localisation))]
        SecondLevel =200003,

        [Display(Name = "ThirdLevel", ResourceType = typeof(Localisation))]
        ThirdLevel =200004
    }
}