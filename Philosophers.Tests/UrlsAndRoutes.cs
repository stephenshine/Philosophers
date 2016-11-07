using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Routing;
using System.Reflection;
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

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
