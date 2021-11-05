using Fanex.Data.Repository;
using UniversalReports.SMAWinLoss.Constants;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class AvailableDateDataCriteria : CriteriaBase
    {
        public AvailableDateDataCriteria()
        {
            TaskId = TaskIdConstant.DailyTask;
        }

        public int TaskId { get; }

        public override string GetSettingKey() => "SMAWinLoss-ReportLatestDate";

        public override bool IsValid() => true;
    }
}