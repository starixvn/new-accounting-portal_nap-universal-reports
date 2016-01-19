using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
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
        public void Query_DateRangeForThreeSources()
        {
            // Arrange
            var criteria = CreateCriteria();
            var rawWinLossService = CreateRawWinLossService();

            // Act
            rawWinLossService.Query(criteria);
        }

        private RawWinLossService CreateRawWinLossService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooser(balanceUpService);

            var calculationService = new CalculationService();
            return new RawWinLossService(dynamicRepository, calculationService, balanceUpSourceChooser);
        }

        private WinLossCriteria CreateCriteria()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpService(dynamicRepository);
            var balanceUpRange = balanceUpService.Query();

            return new WinLossCriteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }
    }
}
