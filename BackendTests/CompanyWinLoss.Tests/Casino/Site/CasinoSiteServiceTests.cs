using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.Site;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CasinoSiteServiceTests : BaseSiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                BetType = 2101,
                Site = "Credit"
            };
        }
    }
}
