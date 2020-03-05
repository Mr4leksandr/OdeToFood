﻿using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Tests.Controllers
{
    class FakeOdeToFoodDb : IOdeToFoodDb
    {
        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
        public List<object> Added = new List<object>();
        public List<object> Updated = new List<object>();
        public List<object> Removed = new List<object>();
        public bool Saved = false;

        public void Add<T>(T entity) where T : class
        {
            Added.Add(entity);
        }

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

        public void Removes<T>(T entity) where T : class
        {
            Removed.Add(entity);
        }

        public void Save<T>(T entity) where T : class
        {
            Saved = true;
        }

        public void Update<T>(T entity) where T : class
        {
            Updated.Add(entity);
        }
    }
}