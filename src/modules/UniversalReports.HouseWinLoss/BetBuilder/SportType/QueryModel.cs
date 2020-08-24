using System;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.BetBuilder.SportType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}