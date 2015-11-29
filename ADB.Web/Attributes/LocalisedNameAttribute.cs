using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ADB.Web.App_GlobalResources;

namespace ADB.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]
    public class LocalisedNameAttribute : DisplayNameAttribute
    {
        public LocalisedNameAttribute([CallerMemberName] string displayName = null)
            : base(GetLocalizedString(displayName))
        {
        }

        public static string GetLocalizedString(string id)
        {
            return id == null ? string.Empty : Localisation.ResourceManager.GetString(id);
        }
    }
}