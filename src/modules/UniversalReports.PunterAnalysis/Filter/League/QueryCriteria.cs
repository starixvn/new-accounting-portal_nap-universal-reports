using Fanex.Data;
using Fanex.Data.Repository;
using System;

namespace UniversalReports.PunterAnalysis.Filter.League
{
    public class QueryCriteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [SpParam(SqlParamName = "SportType")]
        public int SportId { get; set; }

        public override string GetSettingKey() => "Punter-LeagueQuery";

        public override bool IsValid() => true;
    }
}
