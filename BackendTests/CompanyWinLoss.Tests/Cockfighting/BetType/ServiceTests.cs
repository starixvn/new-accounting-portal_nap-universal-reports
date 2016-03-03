using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.BetType;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Cockfighting.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class ServiceTests : BaseBetTypeServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
            };
        }
    }
}
