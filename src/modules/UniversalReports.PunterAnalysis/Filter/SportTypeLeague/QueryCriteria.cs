using Fanex.Data.Repository;
using System;

namespace UniversalReports.PunterAnalysis.Filter.SportTypeLeague
{
    public class QueryCriteria: CriteriaBase
    {
        public int SportId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public override string GetSettingKey() => "Punter-SportTypeLeagueQuery";

        public override bool IsValid() => true;
    }
}
