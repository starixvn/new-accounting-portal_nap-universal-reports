using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.UnitTests.Utility
{
    public class FakeWinLossCriteria : WinLossCriteria
    {
        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            return this;
        }
    }
}
