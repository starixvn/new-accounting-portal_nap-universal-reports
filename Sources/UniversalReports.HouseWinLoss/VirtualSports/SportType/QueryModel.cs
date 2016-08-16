using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.HouseWinLoss.VirtualSports.SportType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;
    }
}