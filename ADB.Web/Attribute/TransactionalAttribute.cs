using System;
using System.Web.Mvc;
using Levshits.Data.Common;

namespace ADB.Web.Attribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class TransactionalAttribute: ActionFilterAttribute
    {
        public IDataProvider DataProvider { get; set; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                DataProvider.CommitTransaction();
            }
            catch (Exception)
            {
                DataProvider.RollbackTransaction();
                DataProvider.CloseSession();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}