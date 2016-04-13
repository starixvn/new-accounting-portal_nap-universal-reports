using NUnit.Framework;
using UniversalReports.CompanyWinLoss.ColossusBets.Site;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.ColossusBets.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class ColossusBetsSiteServiceTests : BaseSiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                Site = "Credit"
            };
        }
    }
}
