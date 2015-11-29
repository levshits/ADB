using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;
using Spring.Web.Mvc;

namespace ADB.Web
{
    public class MvcApplication : SpringMvcApplication
    {
        private static ILog _log =
           LogManager.GetLogger("WebAppBasicNHibernateLogger");
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            XmlConfigurator.Configure();
            _log.Debug("App started");
        }
    }
}
