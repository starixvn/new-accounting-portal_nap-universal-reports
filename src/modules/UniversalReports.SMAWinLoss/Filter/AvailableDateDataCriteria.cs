using Fanex.Data.Repository;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class AvailableDateDataCriteria : CriteriaBase
    {
        public AvailableDateDataCriteria()
        {
            TaskId = 58;
        }

        public int TaskId { get; }

        public override string GetSettingKey() => "SMAWinLoss-ReportLatestDate";

        public override bool IsValid() => true;
    }
}