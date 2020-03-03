using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        IOdeToFoodDb _db;

        public HomeController()
        {
            _db = new OdeToFoodDb();
        }

        public HomeController(IOdeToFoodDb db)
        {
            _db = db;
        }

        public ActionResult Autocomplete(string term)
        {
            var model =
                _db.Query<Restaurant>()
                .Where(r => r.Name.StartsWith(term))
                .Take(15)
                .Select(r => new
                {
                    label = r.Name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model = _db.Query<Restaurant>()
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count() 
                }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var model = new AboutModel();
            model.Name = "Aleksandr Klemets";
            model.Location = "Tallinn, Estonia";
            model.Age = 18;

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}