using System;

namespace UniversalReports.DailyTurnoverComparison.Model
{
    public class TurnoverModel
    {
        public DateTime RptDate { get; set; }

        public string WeekDays { get; set; }

        public string SiteName { get; set; }

        public int Hour { get; set; }

        public int ActiveMembers { get; set; }

        public decimal? ActiveMemberDiff { get; set; }

        public decimal MemberTurnover { get; set; }

        public decimal? TODiff { get; set; }
    }
}