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
        private readonly string PassWord;

        public ExcelResult(ExcelPackage excelPackage, string password = "")
        {
            ExcelPackage = excelPackage;
            PassWord = password;
        }

        public ExcelPackage ExcelPackage { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            using (ExcelPackage)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = string.IsNullOrEmpty(PassWord) ?
                        new ByteArrayContent(ExcelPackage.GetAsByteArray()) :
                        new ByteArrayContent(ExcelPackage.GetAsByteArray(PassWord))
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
