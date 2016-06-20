using System;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Soccer.MainExcel
{
    public class ExcelQueryModel
    {
        public string MajorMinorTitle { get; set; }

        public string LiveNonLiveTitle { get; set; }

        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public bool NormalMode { get; set; } = true;

        public int IsLive { get; set; } = Constants.LiveDefault;
    }
}
