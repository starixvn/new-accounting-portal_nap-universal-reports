using NAP.Reports.CompanyWinLoss.Models.Main;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services.Main;
using NSubstitute;
using NUnit.Framework;
using System;

namespace NAP.Reports.CompanyWinLoss.Controllers.UnitTests
{
    [TestFixture]
    public class MainControllerUnitTests
    {
        [Test]
        [Category("MainControllerUnitTests")]
        public void Values_InvalidDateRange_ReturnsNull()
        {
            // Arrange
            var service = Substitute.For<IMainService>();
            var controller = new MainController(service);
            var model = new MainQuery
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(+1)
            };

            controller.ModelState.AddModelError("DateTo", "DateFrom must be less than DateTo");

            // Act
            var result = controller.Values(model);

            // Assert
            Assert.Null(result);
        }

        [Test]
        [Category("MainControllerUnitTests")]

        public void Values_ValidDateRange_ReturnsDataFromService()
        {
            // Arrange
            var expectedReportData = new MainWinLoss();
            var service = Substitute.For<IMainService>();
            service.Query(Arg.Any<MainQuery>()).Returns(expectedReportData);

            var controller = new MainController(service);
            var model = new MainQuery
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(+1)
            };

            // Act
            var result = controller.Values(model);

            // Assert
            Assert.AreEqual(expectedReportData, result);
        }
    }
}
