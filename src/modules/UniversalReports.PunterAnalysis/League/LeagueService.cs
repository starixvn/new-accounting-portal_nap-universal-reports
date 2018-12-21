using System.Threading.Tasks;
using Fanex.Data.Repository;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public interface LeagueService
    {
        Task<ReportModel> Query(ICriteria criteria);
    }
}