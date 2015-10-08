using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            _log.Debug("App started");
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            RouteConfig.RegisterRoutes(routes);
        }
    }
}
