using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.QueryModels;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace NAP.Reports.CompanyWinLoss.Controllers.UnitTests
{
    [TestFixture]
    public class MainReportControllerUnitTests
    {
        [Test]
        [Category("MainReportControllerUnitTests")]
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
            var result = controller.Values(model).Result;

            // Assert
            Assert.Null(result);
        }

        [Test]
        [Category("MainReportControllerUnitTests")]
        
        public void Values_ValidDateRange_ReturnsDataFromService()
        {
            // Arrange
            var expectedReportData = new MainReportWinLoss();
            var service = Substitute.For<IMainReportService>();
            service.QueryAsync(Arg.Any<MainReportQuery>()).Returns(Task.FromResult(expectedReportData));

            var controller = new MainReportController(service);
            var model = new MainReportQuery
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(+1)
            };

            // Act
            var result = controller.Values(model).Result;

            // Assert
            Assert.AreEqual(expectedReportData, result);
        }
    }
}
