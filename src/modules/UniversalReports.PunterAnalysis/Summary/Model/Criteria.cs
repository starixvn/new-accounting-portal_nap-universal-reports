using Fanex.Data.Repository;
using System;

namespace UniversalReports.PunterAnalysis.Summary.Model
{
    public class Criteria : CriteriaBase
    {
        public int TopRow { get; set; }

        public int OrderBy { get; set; }

        public int SortBy { get; set; }

        public int PeriodType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Depth { get; set; }

        public string UserName { get; set; }

        public string ListCombinationId { get; set; }

        public override string GetSettingKey() => "Punter-Summary";

        public override bool IsValid() => true;
    }
}