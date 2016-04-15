using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.BetType;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Cockfighting.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CockfightingBetTypeServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
            };
        }
    }
}
