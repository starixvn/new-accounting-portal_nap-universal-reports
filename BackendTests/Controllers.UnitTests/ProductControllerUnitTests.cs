using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NSubstitute;
using NUnit.Framework;
using System;

namespace NAP.Reports.CompanyWinLoss.Controllers.UnitTests
{
    [TestFixture]
    public class ProductControllerUnitTests
    {
        [Test]
        public void Values_InvalidDateRange_ReturnsNull()
        {
            // Arrange
            var service = Substitute.For<ProductWinLossService>();
            var controller = new ProductWinLossController(service);
            var model = new ProductWinLossQuery
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
        public void Values_ValidDateRange_ReturnsDataFromService()
        {
            // Arrange
            var expectedReportData = new ProductWinLoss();
            var service = Substitute.For<ProductWinLossService>();
            service.Query(Arg.Any<WinLossCriteria>()).Returns(expectedReportData);

            var controller = new ProductWinLossController(service);
            var model = new ProductWinLossQuery
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
