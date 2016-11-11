using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using Philosophers;
using System.Data.Entity;
using Philosophers.Controllers;

namespace Philosophers.Tests
{
    [TestClass]
    public class AreaTests
    {
        [TestMethod]
        public void IndexActionTest()
        {
            // Arrange
            AreasController target = new AreasController();

            // Act
            ViewResult result = target.Index() as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }
    }
}
