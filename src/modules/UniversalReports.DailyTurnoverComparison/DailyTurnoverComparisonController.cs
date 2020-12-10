using OfficeOpenXml;
using Olympus.WebApi.Epplus;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.DailyTurnoverComparison
{
    [RoutePrefix("api/daily-turnover-comparison")]
    public class DailyTurnoverComparisonController : ApiController
    {
        [Route("top-licensees")]
        public async Task<IHttpActionResult> Excel(int topLicensees)
        {
            var excelPackage = new ExcelPackage();
            return new EpplusExcelResult(excelPackage);
        }
    }
}