using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    [RoutePrefix("api/company-win-loss/live-casino/bet-type")]
    public class LiveCasinoBetTypeController : ApiController
    {
        private readonly BetTypeService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public LiveCasinoBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService gridOptionService)
        {
            this.winlossService = betTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelModel queryModel)
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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}