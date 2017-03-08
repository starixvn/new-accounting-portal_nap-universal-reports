using Fanex.Data.Repository;
using System;

namespace UniversalReports.PunterAnalysis.SportType.Model
{
    public class Criteria : CriteriaBase
    {
        public int PeriodType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int CustId { get; set; }

        public string ListCombinationId { get; set; }

        public override string GetSettingKey() => "Punter-SportType";

        public override bool IsValid() => true;
    }
}