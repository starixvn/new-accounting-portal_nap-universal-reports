using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class BaseSiteServiceTests : BaseServiceTests
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

        protected SiteService CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new SiteServiceImp(rawWinLossService, calculationService);
        }        
    }
}
