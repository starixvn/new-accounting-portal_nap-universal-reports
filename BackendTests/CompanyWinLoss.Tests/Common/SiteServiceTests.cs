using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.SiteWinLoss;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class SiteServiceTests
    {
        protected abstract WinLossCriteria CreateCriteria();

        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = SimpleInjectorContainer.Instance.GetInstance<SiteService>();

            // Act
            service.Query(criteria);
        }
    }
}
