using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Food(string name, string type)
        {
            return Content("name = "+name+" type = "+type);
        }
    }
}