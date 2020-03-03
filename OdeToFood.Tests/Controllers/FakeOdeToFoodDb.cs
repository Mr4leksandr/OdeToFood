using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Tests.Controllers
{
    class FakeOdeToFoodDb : IOdeToFoodDb
    {
        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();

        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof(T), objects);
        }
        public void Dispose()
        {

        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }
    }
}