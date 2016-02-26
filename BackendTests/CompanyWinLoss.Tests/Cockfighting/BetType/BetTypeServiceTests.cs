using Fanex.Data.Configuration;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.BetType;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Cockfighting.BetType
{
    public class BetTypeServiceTests : BaseServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        [Category("CompanyWinLossIntegrationTests")]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = CreateService();

            // Act
            service.Query(criteria);
        }

        private BetTypeServiceImp CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new BetTypeServiceImp(rawWinLossService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2),
            };
        }
    }
}
