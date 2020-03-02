using System;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public RatingResult ComputerResult(IRatingAlgorithm algorithm, int numberOfReviews)
        {
            var filteredReviews = _restaurant.Reviews.Take(numberOfReviews);
            return algorithm.Compute(_restaurant.Reviews.ToList());
        }
    }
}