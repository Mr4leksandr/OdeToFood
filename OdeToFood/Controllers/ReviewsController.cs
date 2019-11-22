﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude="ReviewerName")] RestaurantsReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
                base.Dispose(disposing);
            }
        }
        //// GET: Reviews
        //public ActionResult Index()
        //{
        //    var mode =
        //        from r in _reviews
        //        orderby r.Country
        //        select r;

        //    return View();
        //}

        //// GET: Reviews/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Reviews/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Reviews/Create
        

        //// GET: Reviews/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var review = _reviews.Single(r => r.Id == id);

        //    return View(review);
        //}

        //// POST: Reviews/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    var review = _reviews.Single(r => r.Id == id);
        //    if (TryUpdateModel(review))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(review);
        //}

        //// GET: Reviews/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Reviews/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create(RestaurantsReview review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Reviews.Add(review);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index", new { id = review.RestaurantId });
        //    }
        //    return View(review);
        //}
        //static List<RestaurantsReview> _reviews = new List<RestaurantsReview>
        //{
        //    new RestaurantsReview
        //    {
        //        Id = 1,
        //        ReviewerName = "Orbital ISS SpaceFood",
        //        City = "Space",
        //        Country ="NoCountryJustSpace",
        //        Rating = 10
        //    }
        //};
    }
}