using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Models.Enumerations
{
    public enum CurrencyTypeEnum
    {
        [Display(Name = "BYR", ResourceType = typeof(Localisation))]
        BYR,
        [Display(Name = "USD", ResourceType = typeof(Localisation))]
        USD,
        [Display(Name = "EUR", ResourceType = typeof(Localisation))]
        EUR
    }
}