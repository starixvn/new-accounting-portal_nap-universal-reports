using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.ThirdPartyProduct
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CasinoThirdPartyProductServiceTests : BaseBasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1)
            };
        }
    }
}
