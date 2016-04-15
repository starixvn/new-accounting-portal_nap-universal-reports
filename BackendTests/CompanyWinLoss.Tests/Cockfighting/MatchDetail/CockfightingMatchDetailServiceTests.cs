using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.Tests.Cockfighting.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CockfightingMatchDetailServiceTests
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
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-2),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(2)
            };
        }
    }
}
