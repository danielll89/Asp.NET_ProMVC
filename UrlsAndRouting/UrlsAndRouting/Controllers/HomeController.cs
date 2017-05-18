using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRouting.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        public ActionResult CustomVariable(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id ?? "<no value>";// RouteData.Values["id"];
            return View();
        }

        public ViewResult MyActionMethod()
        {
            string myActionUrl = Url.Action("Index", new { id = "MyId" });
            string myRouteUrl = Url.RouteUrl(new { controller = "Home", action = "Index" });
            // .. do something with urls...
            return View();
        }

        public RedirectToRouteResult MyActionMethod2()
        {
            // return RedirectToAction("Index");
            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index",
                id = "MyID"
            });
        }
    }
}