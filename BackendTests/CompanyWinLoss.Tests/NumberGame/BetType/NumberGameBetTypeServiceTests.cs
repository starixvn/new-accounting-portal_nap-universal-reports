using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.NumberGame.BetType;

namespace UniversalReports.CompanyWinLoss.Tests.NumberGame.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class NumberGameBetTypeServiceTests
    {
        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = SimpleInjectorContainer.Instance.GetInstance<Service>();

            // Act
            service.Query(criteria);
        }

        protected WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1)
            };
        }
    }
}
