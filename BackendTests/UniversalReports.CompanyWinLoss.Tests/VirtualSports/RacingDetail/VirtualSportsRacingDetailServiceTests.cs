using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailByCode;
using UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.RacingDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class VirtualSportsRacingDetailServiceTests
    {
        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = SimpleInjectorContainer.Instance.GetInstance<WinLossService>();

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
