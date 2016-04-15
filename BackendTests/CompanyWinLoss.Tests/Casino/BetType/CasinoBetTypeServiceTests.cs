using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.BetType;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.BetType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CasinoBetTypeServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                ProductId = 6
            };
        }
    }
}
