using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            // Arrange
            Mock<IAuthProvider> auth = new Mock<IAuthProvider>();
            auth.Setup(m => m.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            AccountController controller = new AccountController(auth.Object);
            LoginViewModel loginVM = new LoginViewModel
            {
                UserName = "",
                Password = ""
            };

            // Act
            ActionResult result = controller.Login(loginVM, "/myUrl");

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/myUrl", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            // Arrange
            Mock<IAuthProvider> auth = new Mock<IAuthProvider>();
            auth.Setup(m => m.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            AccountController controller = new AccountController(auth.Object);
            LoginViewModel loginVM = new LoginViewModel
            {
                UserName = "",
                Password = ""
            };

            // Act
            ActionResult result = controller.Login(loginVM, "/myUrl");

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
