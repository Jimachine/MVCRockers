using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRockers.Controllers
{
    public class HomeController : Controller
    {
        // Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "What do you think?";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string Message)
        {
            //save this and act on it
            ViewBag.Message = "Thanks for the feedback!";
            return View();
        }

        public ActionResult Backstage(string secret, string format)
        {
            if (secret != "special")
                return new HttpStatusCodeResult(403);

            if (format == "text")
            {
                return Content("You Rock!");
            }
            else if (format == "json")
            {
                return Json(new { password = "You Rock!", expires = DateTime.Now.ToShortDateString() },
                    JsonRequestBehavior.AllowGet);
            }
            else if (format == "clean")
            {
                return PartialView();
            }
            return View();
        }
    }
}