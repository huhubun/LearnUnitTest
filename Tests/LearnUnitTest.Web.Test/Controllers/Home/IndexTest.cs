using LearnUnitTest.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnUnitTest.Web.Test.Controllers.Home
{
    public class IndexTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var index = homeController.Index();

            // Assert
            Assert.NotNull(index);
        }
    }
}
