using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.MetricGaming.Site;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.MetricGaming.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class MetricGamingSiteServiceTests : BaseSiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                BetType = 1,
                Site = "Credit",
                IsLive = 2
            };
        }
    }
}
