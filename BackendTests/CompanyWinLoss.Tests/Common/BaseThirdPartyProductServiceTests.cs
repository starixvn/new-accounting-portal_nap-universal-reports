using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class BaseThirdPartyProductServiceTests : BaseServiceTests
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

        private ThirdPartyProductServiceImp CreateService()
        {
            var rawService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new ThirdPartyProductServiceImp(rawService, calculationService);
        }
    }
}
