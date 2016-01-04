using NAP.Reports.CompanyWinLoss.QueryModels;
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
            var controller = new MainReportController();
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
    }
}
