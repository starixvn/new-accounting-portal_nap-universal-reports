using Fanex.Data.Repository;
using System;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.League.Model
{
    public class Criteria : BetCountAndLeagueCriteriaBase
    {
        public override string GetSettingKey() => "Punter-League";
    }
}
