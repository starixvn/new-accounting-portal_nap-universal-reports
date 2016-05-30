using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.VirtualSports.BetType;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class VirtualSportsBetTypeServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                SportType = 180
            };
        }
    }
}
