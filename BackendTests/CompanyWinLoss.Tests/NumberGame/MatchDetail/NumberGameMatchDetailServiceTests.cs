using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.NumberGame.MatchDetail;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.NumberGame.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class NumberGameMatchDetailServiceTests 
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
                BetType = 81,
                IsLive = true,
                SportType = 161
            };
        }
    }
}
