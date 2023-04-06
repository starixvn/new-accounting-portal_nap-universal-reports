using System.Collections.Generic;

namespace UniversalReports.SMAWinLoss.Filter
{
    public class LeagueGroup
    {
        public string GroupName { get; set; }

        public string LeagueIds { get; set; }

        public IEnumerable<LeagueGroupChildItem> ChildItems { get; set; }
    }
}