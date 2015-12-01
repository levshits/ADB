using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;


namespace ADB.Web.Models.Enumerations
{
    public enum MaritalStatus
    {
        [Display(Name = "Single", ResourceType = typeof(Localisation))]
        Single =100001,

        [Display(Name = "Married", ResourceType = typeof(Localisation))]
        Married =100002,

        [Display(Name = "Divorsed", ResourceType = typeof(Localisation))]
        Divorsed =100003
    }
}