using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.NumberGame.Summary;
using UniversalReports.CompanyWinLoss.Tests.Common;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.NumberGame.Summary
{
    public class ServiceTests : BaseServiceTests
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

        private ServiceImp CreateService()
        {
            var rawService = CreateNumberGameRawService();
            var commonCalculationService = new CommonServices.CalculationServiceImp();
            var calculationService = new CalculationServiceImp(commonCalculationService);
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

        protected virtual RawService CreateNumberGameRawService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new CommonServices.BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new CommonServices.BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            return new RawServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }
    }
}
