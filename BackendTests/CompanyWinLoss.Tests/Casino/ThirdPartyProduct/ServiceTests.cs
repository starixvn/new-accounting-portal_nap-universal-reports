using Fanex.Data.Configuration;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.ThirdPartyProduct
{
    [TestFixture]
    [Category("CasinoIntegrationTests")]
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
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }

        private ThirdPartyProductServiceImp CreateService()
        {
            var rawService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new ThirdPartyProductServiceImp(rawService, calculationService);
        }
    }
}
