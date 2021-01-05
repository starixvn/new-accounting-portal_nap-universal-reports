using Olympus.WebApi.Epplus;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.DailyTurnoverComparison.Service;

namespace UniversalReports.DailyTurnoverComparison
{
    [RoutePrefix("api/daily-turnover-comparison")]
    public class DailyTurnoverComparisonExportController : ApiController
    {
        private readonly DataService dataService;
        private readonly ExcelService excelService;

        public DailyTurnoverComparisonExportController(
            DataService dataService,
            ExcelService excelService)
        {
            this.dataService = dataService;
            this.excelService = excelService;
        }

        [Route("top-licensees")]
        public IHttpActionResult Excel(HttpRequestParameter parammeter)
        {
            var dataTables = dataService.Query(parammeter);
            var excelPackage = excelService.Export(dataTables);
            return new EpplusExcelResult(excelPackage);
        }
    }
}