using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.VirtualSports.SportType;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.SportType
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class VirtualSportsSportTypeServiceTests : BasicWinLossServiceTests
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
