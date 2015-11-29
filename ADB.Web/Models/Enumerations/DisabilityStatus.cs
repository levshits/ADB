using ADB.Web.Attributes;

namespace ADB.Web.Models.Enumerations
{
    public enum DisabilityStatus
    {
        [LocalisedName]
        None=200000,
        [LocalisedName]
        FirstLevel =200001,
        [LocalisedName]
        SecondLevel =200003,
        [LocalisedName]
        ThirdLevel =200004
    }
}