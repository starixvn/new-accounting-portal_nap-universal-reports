using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NSubstitute;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class SportsbookWinLossServiceTests : ReportServiceBaseTests
    {
        [Test]
        [Category("IntegrationDataService")]
        public void Query_DateRangeForThreeSources()
        {
            // Arrange
            var sportsbookWinLossService = CreateSportsbookWinLossService();

            // Act
            sportsbookWinLossService.Query(MainReportQuery);
        }

        private SportsbookWinLossService CreateSportsbookWinLossService()
        {
            var balanceUpService = Substitute.For<IBalanceUpService>();
            balanceUpService.Query().Returns(BalanceUpRange);
            var balanceUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            var dynamicRepository = new DynamicRepository();
            var calculationService = new CalculationService();
            return new SportsbookWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);
        }
    }
}
