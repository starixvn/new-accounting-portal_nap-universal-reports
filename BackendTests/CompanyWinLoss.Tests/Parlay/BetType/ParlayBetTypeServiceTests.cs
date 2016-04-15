using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Parlay.BetType;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Parlay.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class ParlayBetTypeServiceTests : BasicWinLossServiceTests
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
