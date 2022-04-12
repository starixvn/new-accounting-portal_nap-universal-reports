using Fanex.Data.Repository;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class PermissionCriteria : CriteriaBase
    {
        public string FunctionKey { get; set; }

        public override string GetSettingKey() => $"HouseWinLoss-GetPermisionProfileID";

        public override bool IsValid() => true;
    }
}
