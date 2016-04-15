using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.MetricGaming.BetType;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.MetricGaming.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class MetricGamingBetTypeServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                IsLive = 2
            };
        }
    }
}
