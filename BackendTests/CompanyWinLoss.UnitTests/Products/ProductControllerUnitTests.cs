using NSubstitute;
using NUnit.Framework;
using System;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Products;

namespace UniversalReports.CompanyWinLoss.UnitTests.Products
{
    [TestFixture]
    public class ProductControllerUnitTests
    {
        [Test]
        public void Values_InvalidDateRange_ReturnsNull()
        {
            // Arrange
            var model = new ProductWinLossQuery
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(+1)
            };

            var service = Substitute.For<Service>();
            using (var controller = new ProductController(service))
            {
                controller.ModelState.AddModelError("DateTo", "DateFrom must be less than DateTo");

                // Act
                var result = controller.Values(model);

                // Assert
                Assert.Null(result);
            }
        }

        [Test]
        public void Values_ValidDateRange_ReturnsDataFromService()
        {
            // Arrange
            var expectedReportData = new ProductWinLoss();
            var service = Substitute.For<Service>();
            service.Query(Arg.Any<WinLossCriteria>()).Returns(expectedReportData);
            var model = new ProductWinLossQuery
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(+1)
            };

            using (var controller = new ProductController(service))
            {
                // Act
                var result = controller.Values(model);

                // Assert
                Assert.AreEqual(expectedReportData, result);
            }
        }
    }
}
