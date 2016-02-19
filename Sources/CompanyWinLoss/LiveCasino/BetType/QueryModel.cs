using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public int ProductId { get; set; }

        public string BreadCumb { get; set; }
    }
}
