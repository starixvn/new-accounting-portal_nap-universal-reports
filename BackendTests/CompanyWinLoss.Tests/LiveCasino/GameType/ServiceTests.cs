using Fanex.Data.Configuration;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.LiveCasino.GameType;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.LiveCasino.GameType
{
    [TestFixture]
    [Category("LiveCasinoIntegrationTests")]
    public class ServiceTests : BaseServiceTests
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

        public Criteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2),
                ProductId = 4
            };
        }

        private ServiceImp CreateService()
        {
            var rawService = CreateRawService();
            var calculationService = new CalculationServiceImp();
            return new ServiceImp(rawService, calculationService);
        }
    }
}
