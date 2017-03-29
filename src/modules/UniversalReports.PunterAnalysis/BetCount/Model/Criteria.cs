using Fanex.Data.Repository;
using System;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class Criteria : CriteriaBase
    {
        public int PeriodType { get; set; } = 1;

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int CustId { get; set; }

        public string ListCombinationId { get; set; }

        public int SportId { get; set; }

        public int BetTypeId { get; set; }

        public int LiveStatusId { get; set; }

        public override string GetSettingKey() => "Punter-BetCount";

        public override bool IsValid() => true;
    }
}