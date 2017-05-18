using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            var aa = TempData["dudu"];

            DateTime date = DateTime.Now;
            return View(date);
        }

        //public RedirectResult Redirect()
        //{
        //    return RedirectPermanent("/Example/Index");
        //}

        public RedirectToRouteResult Redirect()
        {
            TempData["dudu"] = new BasicController();

            return RedirectToAction("Index");
            //return RedirectToRoute(new
            //{
            //    controller = "Example",
            //    action = "Index",
            //    ID = "MyID"
            //});
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "URL cannot be serviced");
        }
    }
}