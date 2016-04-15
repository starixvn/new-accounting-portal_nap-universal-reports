using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.SportsbookDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class VirtualSportsSportsbookDetailServiceTests
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
                BetType = 1231,
                SportType = 181
            };
        }
    }
}
