using Fanex.Data.Repository;

namespace UniversalReports.DailyTurnoverComparison.Criterias
{
    public class GetDWStatusCriteria : CriteriaBase
    {
        public string TaskIDList { get; set; }

        public override string GetSettingKey()
        {
            return "DailyJob_CheckTasksStatus";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}