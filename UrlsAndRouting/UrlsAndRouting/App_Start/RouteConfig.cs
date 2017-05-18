using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;
using UrlsAndRouting.Infrastructure;

namespace UrlsAndRouting
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region chapter 1
            //** Example 1 **//
            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add(myRoute);

            //** Example 2 **//
            //routes.MapRoute("ShopShema2", "Shop/OldAction", new { controller = "Home", action = "Index" });
            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });
            //routes.MapRoute("", "X{controller}/{action}");
            //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" });
            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });

            //** Example 3 **//
            //routes.MapRoute("MapRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "DefaultId" });
            //routes.MapRoute("MapRoute", "{controller}/{action}/{id}/{*catchcall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //** Constrains **//

            //routes.MapRoute("ChromeRoute", "{*catchall}",
            //    new { controller = "Customer", action = "Index" },
            //    new { customConstraint = new UserAgentConstraint("Chrome") },
            //    new[] { "UrlsAndRouting.AdditionalControllers" });

            //Route myRoute = routes.MapRoute("MapRoute", "{controller}/{action}/{id}",
            //    new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    },
            //    new
            //    {
            //        controller = "^H.*",
            //        action = "^Index$|^About&",
            //        httpMethod = new HttpMethodConstraint("GET", "POST"),
            //        id = new CompoundRouteConstraint(new IRouteConstraint[]
            //        {
            //            new AlphaRouteConstraint(),
            //            new MinLengthRouteConstraint(6)
            //            //new RangeRouteConstraint(10, 20)
            //        })
            //    },
            //    new[] { "UrlsAndRouting.AdditionalControllers" });
            //myRoute.DataTokens["UseNamespaceFallback"] = false;

            // ** Attribute routing **//
            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute("Default", "{controller}/{action}/{id}",
            //new
            //{
            //    controller = "Home",
            //    action = "Index",
            //    id = UrlParameter.Optional
            //},
            //new[] { "UrlsAndRoutes.Controllers" });
            #endregion

            routes.RouteExistingFiles = true;
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("Content/{filename}.html");

            //routes.MapRoute("NewRoute", "App/Do{action}",
            //   new { controller = "Home" });

            //routes.MapRoute("Default", "{controller}/{action}/{id}",
            //new
            //{
            //    controller = "Home",
            //    action = "Index",
            //    id = UrlParameter.Optional
            //});

            routes.Add(new LegacyRoute(
                "~/articles/Windows_3.1_Overview.html",
                "~/old/.NET_1.0_Class_Library"));

            routes.MapRoute("MyRoute", "{controller}/{action}", null, new[] { "UrlsAndRouting.Controllers" });
            routes.MapRoute("MyOtherRoute", "App/{action}", new
            {
                controller = "Home"
            }, new[] { "UrlsAndRouting.Controllers" });
        }
    }

}
