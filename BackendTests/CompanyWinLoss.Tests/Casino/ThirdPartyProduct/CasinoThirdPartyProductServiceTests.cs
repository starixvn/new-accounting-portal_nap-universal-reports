using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.ThirdPartyProduct
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CasinoThirdPartyProductServiceTests : BasicWinLossServiceTests
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
