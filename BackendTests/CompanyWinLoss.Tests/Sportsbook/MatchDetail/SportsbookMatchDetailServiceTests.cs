using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail;

namespace UniversalReports.CompanyWinLoss.Tests.MetricGamingSportsbook.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SportsbookMatchDetailServiceTests
    {
        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = SimpleInjectorContainer.Instance.GetInstance<MatchDetailWinLossService>();

            // Act
            service.Query(criteria);
        }

        protected WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                BetType = 1,
                SportType = 1,
                IsLive = 2,
                IsHedge = false
            };
        }
    }
}
