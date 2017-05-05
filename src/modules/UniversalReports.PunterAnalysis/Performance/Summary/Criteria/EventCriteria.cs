using Fanex.Data.Repository;
using System;

namespace UniversalReports.PunterAnalysis.Performance.Summary.Criteria
{
    public class EventCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Depth { get; set; }

        public string Username { get; set; }

        public override string GetSettingKey() => "Punter-Performance-Event";

        public override bool IsValid() => true;
    }
}