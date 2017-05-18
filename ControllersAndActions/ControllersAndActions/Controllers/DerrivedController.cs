using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class DerrivedController : Controller
    {
        public ActionResult Index()
        {
            var x = this;
            string userName = User.Identity.Name;
            string serverName = Server.MachineName;
            string clientIP = Request.UserHostAddress;
            DateTime dateStamp = HttpContext.Timestamp;


            ViewBag.Message = "Hello from the DerivedController Index method";
            return  View("MyView"); //new HttpUnauthorizedResult();
        }

        public ActionResult ProduceOutput()
        {
            if (Server.MachineName == "TINY")
            {
                return new CustomRedirectResult { Url = "/Basic/Index" };
            }
            else
            {
                Response.Write("Controller: Derived, Action: ProduceOutput");
                return null;
            }
        }
    }
}