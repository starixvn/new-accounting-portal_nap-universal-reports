using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;
using UniversalReports.CompanyWinLoss.Tests.Common;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.NumberGame.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class ServiceTests : BaseServiceTests
    {
        [Test]
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
            var rawWinLossService = CreateNumberGameRawService();
            var commonCalculationService = new CommonServices.CalculationServiceImp();
            var calculationService = new CommonServices.CalculationServiceImp();
            return new ServiceImp(rawWinLossService, calculationService);
        }

        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1)
            };
        }

        protected virtual CommonServices.RawWinLossService CreateNumberGameRawService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new CommonServices.BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new CommonServices.BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new CommonServices.BalanceUpSummationServiceImp();
            return new CommonServices.RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }
    }
}
