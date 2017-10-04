using System;
using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.Shared
{
    public abstract class BetCountAndLeagueCriteriaBase : CriteriaBase
    {
        public int PeriodType { get; set; } = 1;

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int CustId { get; set; }

        public string ListCombinationId { get; set; }

        public int LeagueId { get; set; }

        public int SportId { get; set; }

        public int BetTypeId { get; set; }

        public int LiveStatusId { get; set; }

        public override bool IsValid() => true;
    }
}