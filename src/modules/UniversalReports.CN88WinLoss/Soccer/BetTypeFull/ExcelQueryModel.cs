using System;

namespace UniversalReports.CN88WinLoss.Soccer.BetTypeFull
{
    public class ExcelQueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public bool IsMajor { get; set; }

        public string BetTypeFullTitle { get; set; }

        public string BetTypeLiveTitle { get; set; }

        public string BetTypeNonLiveTitle { get; set; }
    }
}