using System.ComponentModel.DataAnnotations;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Models.Enumerations
{
    public enum ContractTypeEnum
    {
        [Display(Name = "DepositContract", ResourceType = typeof(Localisation))]
        DepositContract = 1,

        [Display(Name = "CreditContract", ResourceType = typeof(Localisation))]
        CreditContract = 2
    }
}