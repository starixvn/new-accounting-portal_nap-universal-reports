using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.OtherSports.LiveNonLive
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class OtherSportsLiveNonLiveServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1)
            };
        }
    }
}
