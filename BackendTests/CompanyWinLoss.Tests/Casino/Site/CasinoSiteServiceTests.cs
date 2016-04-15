using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.Site;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CasinoSiteServiceTests : SiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                BetType = 2101,
                Site = "Credit"
            };
        }
    }
}
