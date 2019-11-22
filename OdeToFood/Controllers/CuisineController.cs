using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class CuisineController : Controller
    {
        [AllowAnonymous]
        [Log]
        // GET: Cuisine
        public ActionResult Search(string name="?")
        {
            var message = Server.HtmlEncode("Otsitav"+name);

            return Content(message);
        }
        public ActionResult File()
        {
            return File(Server.MapPath("~/Content/site.css"), "text/css");
        }
        public ActionResult Json()
        {
            return Json(Server, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult Error()
        {
            throw new Exception("Something went horribly wrong.");
            //return RedirectToAction("Index","Home");
        }
    }
}