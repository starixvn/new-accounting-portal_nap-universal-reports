using System;
using Fanex.Data.Repository;

namespace UniversalReports.Exchange.Report
{
    public class Criteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string LicenseeId { get; set; }

        public string SportType { get; set; }

        public override string GetSettingKey() => "Exchange-ReportQuery";

        public override bool IsValid() => true;
    }
}