using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class BasicWinLossServiceTests
    {
        protected abstract WinLossCriteria CreateCriteria();

        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = SimpleInjectorContainer.Instance.GetInstance<BasicWinLossService>();

            // Act
            service.Query(criteria);
        }
    }
}
