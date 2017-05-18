using System;
using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            ViewResult result = target.Index();

            // Assert - check the result
            Assert.AreEqual("", result.ViewName);// "" for default view
        }

        [TestMethod]
        public void ViewSelectionTest()
        {
            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            ViewResult result = target.Index();

            // Assert - check the result
            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(System.DateTime));
        }

        //[TestMethod]
        //public void ControllerTest2()
        //{
        //    // Arrange - create the controller
        //    ExampleController target = new ExampleController();

        //    // Act - call the action method
        //    RedirectResult result = target.Redirect();

        //    // Assert - check the result
        //    Assert.IsTrue(result.Permanent);
        //    Assert.AreEqual("/Example/Index", result.Url);
        //}

        [TestMethod]
        public void ControllerTest3()
        {
            // Arrange - create the controller
            ExampleController target = new ExampleController();

            // Act - call the action method
            RedirectToRouteResult result = target.Redirect();

            // Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["ID"]);
        }
    }
}
