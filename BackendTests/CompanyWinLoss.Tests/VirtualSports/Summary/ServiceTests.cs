using Fanex.Data.Configuration;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.VirtualSports.Summary;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.Summary
{
    public class ServiceTests : BaseServiceTests
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

        private ServiceImp CreateService()
        {
            var rawService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new ServiceImp(rawService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }
    }
}
