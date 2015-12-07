using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Models.Enumerations
{
    public enum CreditContractType
    {
        [Display(Name = "CreditType1", ResourceType = typeof(Localisation))]
        CreditType1 = 1,

        [Display(Name = "CreditType2", ResourceType = typeof(Localisation))]
        CreditType2 = 2
    }
}