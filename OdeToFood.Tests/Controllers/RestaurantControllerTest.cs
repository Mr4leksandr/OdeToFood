using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void Create_Saves_Restaurant_When_Valid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new Restaurants1Controller(db);

            controller.Create(new Models.Restaurant());

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [TestMethod]
        public void Create_Does_Not_Saves_Restaurant_When_Invalid()
        {
            var db = new FakeOdeToFoodDb();
            var controller = new Restaurants1Controller(db);
            controller.ModelState.AddModelError("", "Invalid");

            controller.Create(new Models.Restaurant());

            Assert.AreEqual(0, db.Added.Count);
            Assert.AreEqual(false, db.Saved);
        }
    }
}
