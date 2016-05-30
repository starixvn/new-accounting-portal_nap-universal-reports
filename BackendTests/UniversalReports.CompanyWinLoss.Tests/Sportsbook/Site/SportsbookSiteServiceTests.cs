using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Sportsbook.Site;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Sportsbook.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SportsbookSiteServiceTests : SiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                SportType = 1,
                BetType = 1,
                Site = "Credit",
                IsHedge = false,
                IsLive = 2
            };
        }
    }
}
