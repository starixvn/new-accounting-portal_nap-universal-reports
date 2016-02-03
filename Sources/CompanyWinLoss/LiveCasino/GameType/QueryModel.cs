using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.LiveCasino.GameType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int ProductId { get; set; }
    }
}
