using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.MainReport;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class MainReportServiceTests : ReportServiceBaseTests
    {
        protected const string NumberGame = "Number Game";

        protected const string Sportsbook = "Sportsbook";

        [Test]
        [Category("IntegrationDataService")]
        public void Query_DateRangeForThreeSources()
        {
            // Arrange
            var mainReportService = CreateMainReportService();

            // Act
            mainReportService.Query(MainReportQuery);
        }

        [Test]
        [Category("IntegrationDataService")]
        public void QueryAync_DateRangeForThreeSources()
        {
            // Arrange
            var mainReportService = CreateMainReportService();

            // Act
            var asyncResult = mainReportService.QueryAsync(MainReportQuery);

            Assert.NotNull(asyncResult.Result);
        }

        private MainReportService CreateMainReportService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            var configuration = new Configuration();


            var calculationService = new CalculationService();

            var productWinLossService = new ProductWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);
            var sportsbookWinLossService = new SportsbookWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);

            return new MainReportService(sportsbookWinLossService, productWinLossService, calculationService, configuration);
        }
    }
}
