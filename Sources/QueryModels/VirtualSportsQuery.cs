using NAP.Reports.MVC.Validation;
using System;

namespace NAP.Reports.CompanyWinLoss.QueryModels
{
    public class VirtualSportsQuery
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
    }
}
