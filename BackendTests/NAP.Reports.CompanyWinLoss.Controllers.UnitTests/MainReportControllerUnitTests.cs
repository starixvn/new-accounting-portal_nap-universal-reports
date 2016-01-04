using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services;
using NSubstitute;
using NUnit.Framework;
using System;
namespace NAP.Reports.CompanyWinLoss.Controllers.UnitTests
{
    public class MainReportControllerUnitTests
    {
        [Test]
        public void Values_InvalidDateRange_ReturnsNull()
        {
            // Arrange
            var service = Substitute.For<IMainReportService>();
            var controller = new MainReportController(service);
            var model = new MainReportQuery
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
            var expectedReportData = new MainReportWinLoss();
            var service = Substitute.For<IMainReportService>();
            service.Query(Arg.Any<MainReportQuery>()).Returns(expectedReportData);

            var controller = new MainReportController(service);
            var model = new MainReportQuery
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
