using System.Web.Mvc;
using System.Web.Routing;

namespace WebServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("index.html");

            routes.MapRoute(
                name: "Default",
                url: "index.html",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
