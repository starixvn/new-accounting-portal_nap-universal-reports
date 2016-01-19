using Fanex.Data.Configuration;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class NumberGameMatchDetailWinLossServiceTests : BaseWinLossServiceTests
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

        private NumberGameMatchDetailWinLossService CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationService();
            return new NumberGameMatchDetailWinLossService(rawWinLossService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new NumberGameMatchDetailWinLossCriteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2),
                BetType = 81,
                IsLive = true,
                SportType = 161
            };
        }
    }
}
