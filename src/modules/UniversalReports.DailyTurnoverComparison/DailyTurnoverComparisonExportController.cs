using OfficeOpenXml;
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

        public DailyTurnoverComparisonExportController(DataService dataService)
        {
            this.dataService = dataService;
        }

        [Route("top-licensees")]
        public async Task<IHttpActionResult> Excel(HttpRequestParameter parammeter)
        {
            dataService.Query(parammeter);
            var excelPackage = new ExcelPackage();
            return new EpplusExcelResult(excelPackage);
        }
    }
}