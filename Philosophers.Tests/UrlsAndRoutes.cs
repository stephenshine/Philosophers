﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Routing;
using System.Reflection;
using Philosophers;
using Moq;

namespace Philosophers.Tests
{
    [TestClass]
    public class UrlsAndRoutes
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // create mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();

            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);

            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();

            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create mock context using request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();

            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
            // arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // act
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();

                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string url)
        {
            // arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // act
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            // assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        [TestMethod]
        public void PhilosopherRoutes()
        {
            TestRouteMatch("~/", "Philosophers", "Index");
            TestRouteMatch("~/Philosophers", "Philosophers", "Index");
            TestRouteMatch("~/Philosophers/Index", "Philosophers", "Index");
            TestRouteMatch("~/Philosophers/Details/Chalmers", "Philosophers", "Details", new { lastName = "Chalmers" });
        }
    }
}
