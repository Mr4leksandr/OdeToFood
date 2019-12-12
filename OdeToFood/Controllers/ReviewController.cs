using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewController : Controller
    {
        private OdeToFoodDb db = new OdeToFoodDb();
        public ActionResult BestReview()
        {
            var best = from r in _reviews
                       orderby r.Rating descending
                       select r;
            return PartialView("_Review", best.First());
        }
        // GET: Review
        public ActionResult LatestReviews()
        {
            var model = from r in _reviews
                        orderby r.Country
                        select r;
            return View(model);
        }

        public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
        {
            var restaurant = db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Create ( int restaurantId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View();
        }

        static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview
            {
                Id = 1,
                Name = "Cinnamon Club",
                City = "London",
                Country = "UK",
                Rating = 10
            },
            new RestaurantReview
            {
                Id = 2,
                Name = "Marrakesh",
                City = "D.C",
                Country = "USA",
                Rating = 10
            },
            new RestaurantReview
            {
                Id = 3,
                Name = "The House of Elliot",
                City = "Ohent",
                Country = "Belgium",
                Rating = 10
            }
        };
    }
}