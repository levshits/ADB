using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Models.Enumerations
{
    public enum DepositContractType
    {
        [Display(Name = "DepositType1", ResourceType = typeof(Localisation))]
        DepositType1 = 1,

        [Display(Name = "DepositType2", ResourceType = typeof(Localisation))]
        DepositType2 = 2
    }
}