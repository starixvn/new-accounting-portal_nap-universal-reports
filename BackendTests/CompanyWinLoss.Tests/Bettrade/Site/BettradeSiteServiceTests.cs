using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Bettrade.Site;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Bettrade.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class BettradeSiteServiceTests : SiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                Site = "Deposit"
            };
        }
    }
}
