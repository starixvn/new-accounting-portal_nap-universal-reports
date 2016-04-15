using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Soccer.BetType;

namespace UniversalReports.CompanyWinLoss.Tests.Soccer.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SoccerBetTypeServiceTests
    {
        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = SimpleInjectorContainer.Instance.GetInstance<BasicWinLossService>();

            // Act
            service.Query(criteria);
        }

        protected WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                IsLive = 2,
                IsMajor = true
            };
        }
    }
}
