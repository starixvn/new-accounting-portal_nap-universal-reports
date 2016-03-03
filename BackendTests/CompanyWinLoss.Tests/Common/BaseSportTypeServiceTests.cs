using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class BaseSportTypeServiceTests : BaseServiceTests
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

        private SportTypeServiceImp CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new SportTypeServiceImp(rawWinLossService, calculationService);
        }
    }
}
