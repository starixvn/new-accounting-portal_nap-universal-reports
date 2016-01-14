using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.QueryModels.Main;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Main;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class RawWinLossServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        [Category("IntegrationDataService")]
        public void Query_DateRangeForThreeSources()
        {
            // Arrange
            var query = CreateMainQuery();
            var productWinLossService = CreateRawWinLossService();

            // Act
            productWinLossService.Query(query);
        }

        private RawWinLossService CreateRawWinLossService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            var calculationService = new CalculationService();
            return new RawWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);
        }

        private MainQuery CreateMainQuery()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            var balanceUpRange = balanceUpService.Query();

            return new MainQuery
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }
    }
}
