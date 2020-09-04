using Fanex.Data.Repository;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class AvailableDatabaseCriteria : CriteriaBase
    {
        public AvailableDatabaseCriteria()
        {
            TaskId = 58;
        }

        public int TaskId { get; }

        public override string GetSettingKey() => "SMAWinLoss-AvailabeDatabaseQuery";

        public override bool IsValid() => true;
    }
}