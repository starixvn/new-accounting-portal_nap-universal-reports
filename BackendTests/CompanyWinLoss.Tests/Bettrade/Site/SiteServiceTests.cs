using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Bettrade.Site;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Bettrade.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SiteServiceTests : BaseSiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                Site = "Deposit"
            };
        }
    }
}
