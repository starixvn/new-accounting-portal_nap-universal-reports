using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.Criteria
{
    public class FakeWinLossCriteria : WinLossCriteria
    {
        public override string GetSettingKey()
        {
            return string.Empty;
        }
    }
}