using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.VirtualSports.Site;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class VirtualSportsSiteServiceTests : SiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                SportType = 180,
                BetType = 1203,
                Site = "Credit"
            };
        }
    }
}
