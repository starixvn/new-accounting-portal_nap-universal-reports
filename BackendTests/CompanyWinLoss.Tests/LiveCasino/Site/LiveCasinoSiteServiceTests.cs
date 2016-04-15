using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.LiveCasino.Site;

namespace UniversalReports.CompanyWinLoss.Tests.LiveCasino.Site
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SiteServiceTests : Common.SiteServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                BetType = 1101,
                Site = "Credit"
            };
        }
    }
}
