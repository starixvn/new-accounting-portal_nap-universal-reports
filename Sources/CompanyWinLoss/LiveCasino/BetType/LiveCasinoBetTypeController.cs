using Fanex.Excel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoBetTypeController : ApiController
    {
        private readonly BetTypeService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public LiveCasinoBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService gridOptionService)
        {
            this.winlossService = betTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("bet-type")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    ProductId = queryModel.ProductId
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("export-bet-type")]
        public HttpResponseMessage Export(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response;
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    ProductId = queryModel.ProductId
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);
                var excel = new FanexExcel(gridOptions);
                var workbook = excel.ToExcel2003("sheet1");

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.Write(memoryStream);
                    response = Request.CreateResponse(HttpStatusCode.OK);
                    MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue("application/vnd.ms-excel");
                    response.Content = new ByteArrayContent(memoryStream.ToArray());
                    response.Content.Headers.ContentType = mediaType;
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = "aaa.xls";
                    return response;
                }
            }

            return null;
        }
    }
}
