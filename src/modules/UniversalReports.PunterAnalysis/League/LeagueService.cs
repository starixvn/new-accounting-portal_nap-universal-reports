using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public interface LeagueService
    {
        Task<ReportModel> Query(ICriteria criteria);

        Dictionary<int, List<int>> GetMappingGroups(IEnumerable<LeagueMappingModel> entities);
    }
}
