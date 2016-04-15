using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Bingo.BetType;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Bingo.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class BingoBetTypeServiceTests : BasicWinLossServiceTests
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
