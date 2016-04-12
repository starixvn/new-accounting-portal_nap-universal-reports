using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.MetricGaming.LiveNonLive;

using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.MetricGaming.LiveNonLive
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class MetricGamingLiveNonLiveServiceTests : BaseBasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();
            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1)
            };
        }
    }
}
