using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class Restaurants1Controller : Controller
    {
        IOdeToFoodDb _db;

        public Restaurant()
        {
            db = new OdeToFoodDb();
        }

        public Restaurants1Controller(IOdeToFoodDb db)
        {
            this.db = db;
        }

        private OdeToFoodDb db = new OdeToFoodDb();

        // GET: Restaurants1
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        // GET: Restaurants1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,Country")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Query<Restaurant>().Single(r => r.Id == id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,Country")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Query<Restaurant>().Single(r => r.Id == id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Query<Restaurant>().Single(r=>r.Id==id);
            db.Removes(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
