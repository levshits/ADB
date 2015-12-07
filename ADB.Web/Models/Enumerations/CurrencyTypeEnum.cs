using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Models.Enumerations
{
    public enum CurrencyTypeEnum
    {
        [Display(Name = "BYR", ResourceType = typeof(Localisation))]
        BYR = 1,
        [Display(Name = "USD", ResourceType = typeof(Localisation))]
        USD = 2,
        [Display(Name = "EUR", ResourceType = typeof(Localisation))]
        EUR = 3
    }
}