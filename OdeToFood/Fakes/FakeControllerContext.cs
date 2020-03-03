using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Tests.Fakes
{
    class FakeControllerContext : ControllerContext
    {
        HttpContextBase _context = new FakeHttpContext();

        public override HttpContextBase HttpContext { get => base.HttpContext; set => base.HttpContext = value; }
    }

    class FakeHttpContext : HttpContextBase
    {
        HttpRequestBase _request = new FakeHttpContext();
        public override HttpRequestBase Request => _request;
    }

    class FakeHttpRequest : HttpRequestBase
    {
        public override string this[string key] => null;

        public override NameValueCollection Headers => new NameValueCollection();
    }
}