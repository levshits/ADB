using ADB.Web.Attributes;

namespace ADB.Web.Models.Enumerations
{
    public enum MaritalStatus
    {
        [LocalisedName]
        Single=100001,
        [LocalisedName]
        Married =100002,
        [LocalisedName]
        Divorsed =100003
    }
}