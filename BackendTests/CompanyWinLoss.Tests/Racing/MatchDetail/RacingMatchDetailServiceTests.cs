using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Racing.MatchDetail;

namespace UniversalReports.CompanyWinLoss.Tests.Racing.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class RacingMatchDetailServiceTests
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
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                BetType = 31,
                SportType = 151
            };
        }
    }
}
