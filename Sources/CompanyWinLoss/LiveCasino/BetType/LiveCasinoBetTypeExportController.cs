using Fanex.Excel;
using Fanex.Excel.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using UniversalReports.MVC.Filter;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoBetTypeExportController : ApiController
    {
        [Route("export-bet-type")]
        [JsonFilter(Parameter = "gridOptions")]
        public HttpResponseMessage Export(GridOptions gridOptions)
        {
            var excel = new FanexExcel(gridOptions);
            var workbook = excel.ToExcel2003("sheet1");
            MemoryStream memoryStream = new MemoryStream();
            workbook.Write(memoryStream);
            HttpResponseMessage response;
            response = Request.CreateResponse(HttpStatusCode.OK);
            MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            response.Content = new ByteArrayContent(memoryStream.ToArray());
            response.Content.Headers.ContentType = mediaType;
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "aaa.xls";
            return response;
        }
    }
}
