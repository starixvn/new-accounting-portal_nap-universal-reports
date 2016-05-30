using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Casino.Product;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;

namespace UniversalReports.CompanyWinLoss.Tests.Casino.Product
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class CasinoProductServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                CasinoType = 1
            };
        }
    }
}
