using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Sportsbook.Site;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Sportsbook.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SportsbookSiteServiceTests : BaseSiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                SportType = 1,
                BetType = 1,
                Site = "Credit",
                IsHedge = false,
                IsLive = 2
            };
        }
    }
}
