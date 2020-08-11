using Fanex.Data.Repository;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class LeagueGroupCriteria : CriteriaBase
    {
        public string Sports { get; set; }

        public string SearchText { get; set; }

        public bool SearchExactly { get; set; }

        public override string GetSettingKey() => $"SMAWinLoss-LeagueGroupSel";

        public override bool IsValid() => true;
    }
}