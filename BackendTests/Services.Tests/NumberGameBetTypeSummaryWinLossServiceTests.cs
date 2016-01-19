using Fanex.Data.Configuration;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class NumberGameBetTypeSummaryWinLossServiceTests : BaseWinLossServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        [Category("ServiceIntegrationTests")]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = CreateService();

            // Act
            service.Query(criteria);
        }

        private NumberGameBetTypeSummaryWinLossService CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationService();
            return new NumberGameBetTypeSummaryWinLossService(rawWinLossService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new NumberGameBetTypeSummaryWinLossCriteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }
    }
}
