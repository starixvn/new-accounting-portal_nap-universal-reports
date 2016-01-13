using NAP.Reports.CompanyWinLoss.Models.MainReport;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services.UnitTests.MainReport
{
    public class MainReportServiceIntegrationTests : MainReportServiceBaseTests
    {
        [Test]
        [Category("ServiceUnitTests")]
        public void Query_SportsbookAndNumberGame_CalculateRightGrandTotal()
        {
            // Arrange   
            var expectedGrandTotal = CreateExpectedGrandTotal();
            var calculationService = new CalculationService();
            var configuration = Substitute.For<IConfiguration>();
            configuration.Products.Returns(new List<string> { "Sportsbook", "NumberGame" });

            Initialize();

            // Act 
            MainReportService = new MainReportService(SportsbookWinLossService, ProductWinLossService, calculationService, configuration);
            var result = MainReportService.Query(Query);

            // Assert
            var equal = WinLossComparision.AreTwoProductWinLossEqual(expectedGrandTotal, result.GrandTotal);
            Assert.True(equal);
        }

        private ProductWinLoss CreateExpectedGrandTotal()
        {
            var creditWinLoss = WinLossFactory.CreateWinLoss("Credit", 200, 400, 20, 600, 800, -200, 2000, 2400, 600m / 2000m, 800m / 2400m);
            var depositWinLoss = WinLossFactory.CreateWinLoss("Deposit", 220, 420, 40, 620, 820, -200, 2200, 2600, 620m / 2200m, 820m / 2600m);
            var totalWinLoss = WinLossFactory.CreateWinLoss("Grand Total", 420, 820, 60, 1220, 1620, -400, 4200, 5000, 1220m / 4200, 1620m / 5000);
            return new ProductWinLoss
            {
                Credit = creditWinLoss,
                Deposit = depositWinLoss,
                Total = totalWinLoss
            };
        }
    }
}
