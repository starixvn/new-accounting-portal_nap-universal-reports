using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.Universal.Site;

namespace UniversalReports.CompanyWinLoss.Tests.Universal.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class UniversalSiteServiceTests : SiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                Site = "Deposit",
                BetType = 18000
            };
        }
    }
}
