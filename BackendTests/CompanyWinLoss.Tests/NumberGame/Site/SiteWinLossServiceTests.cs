using Fanex.Data.Configuration;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.NumberGame.Site;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.NumberGame.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SiteWinLossServiceTests : BaseServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]        
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = CreateService();

            // Act
            service.Query(criteria);
        }

        private SiteServiceImp CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new SiteServiceImp(rawWinLossService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2),
                BetType = 81,
                IsLive = true,
                SportType = 161,
                Site = "Credit"
            };
        }
    }
}
