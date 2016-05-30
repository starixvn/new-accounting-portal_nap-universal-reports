using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CommonBalanceUpServiceTests
    {
        [Test]
        public void QueryBalanceUp_Successful()
        {
            // Arrange
            var balanceUpService = SimpleInjectorContainer.Instance.GetInstance<BalanceUpService>();

            // Act
            balanceUpService.Query();
        }
    }
}
