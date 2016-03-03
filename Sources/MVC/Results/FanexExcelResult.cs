using Fanex.Excel;
using Fanex.Excel.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.MVC.Results
{
    public class FanexExcelResult : IHttpActionResult
    {
        public FanexExcelResult(GridOptions gridOptions)
        {
            GridOptions = gridOptions;
        }

        public GridOptions GridOptions { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var excel = new FanexExcel(GridOptions);
            var workbook = excel.ToExcel2003("sheet1");
            using (var memoryStream = new MemoryStream())
            {
                workbook.Write(memoryStream);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(memoryStream.ToArray());
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "undefined.xls"
                };

                return Task.FromResult(response);
            }
        }
    }
}