using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Computer_Result_For_One_Review()
        {
            var data = BuildRestaurantAndReviews(rating:4);

            var rater = new RestaurantRater(data);
            var result = rater.ComputerResult(new SimpleRatingAlgorithm(),10);

            Assert.AreEqual(4, result.Rating);
        }

        [TestMethod]
        public void Computer_Result_For_Two_Review()
        {
            var data= BuildRestaurantAndReviews(rating:new int[] { 4, 8 });

            var rater = new RestaurantRater(data);
            var result = rater.ComputerResult(new SimpleRatingAlgorithm(),10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Weighted_Averaging_For_Two_Reviews()
        {
            var restaurant = BuildRestaurantAndReviews(3, 9);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputerResult(new WeightedRatingAlgorithm(),10);

            Assert.AreEqual(5, result.Rating);
        }

        [TestMethod]
        public void Weighted_Averaging_For_Multiple_Reviews()
        {
            var restaurant = BuildRestaurantAndReviews(2, 2, 0, 0, 0, 0);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputerResult(new WeightedRatingAlgorithm(),5);

            Assert.AreEqual(1, result.Rating);
        }

        private Restaurant BuildRestaurantAndReviews(params int[] rating)
        {
            var restaurant = new Restaurant();
            restaurant.Reviews = rating.Select(r => new RestaurantReview
            { Rating = r }).ToList();
            return restaurant;
        }
    }
}
