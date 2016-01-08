using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cadeau
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<Cadeau.Models.ProductContext>(new Cadeau.Models.InitialData());
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception is HttpException)
            {
                var httpException = (HttpException)exception;
                Response.StatusCode = httpException.GetHttpCode();
            }
        }
    }
}
