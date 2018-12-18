using System;

namespace UniversalReports.HouseWinLoss.NG2.BetType
{
    public class ExcelLiveNonLiveQueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; }

        public string Title { get; set; }

        public string LiveTitle { get; set; }

        public string NonLiveTitle { get; set; }
    }
}