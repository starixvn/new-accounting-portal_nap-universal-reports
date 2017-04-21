using OfficeOpenXml;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.WebAPI.Results
{
    public class ExcelResult : IHttpActionResult
    {
        public ExcelResult(ExcelPackage excelPackage)
        {
            ExcelPackage = excelPackage;
        }

        public ExcelPackage ExcelPackage { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            using (ExcelPackage)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ExcelPackage.GetAsByteArray())
                };
            }

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Excel.xlsx"
            };

            return Task.FromResult(response);
        }
    }
}
