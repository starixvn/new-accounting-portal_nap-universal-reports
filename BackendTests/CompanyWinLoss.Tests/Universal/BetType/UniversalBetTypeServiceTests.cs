using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.Universal.BetType;

namespace UniversalReports.CompanyWinLoss.Tests.Universal.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class UniversalBetTypeServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                ProductId = 7
            };
        }
    }
}
