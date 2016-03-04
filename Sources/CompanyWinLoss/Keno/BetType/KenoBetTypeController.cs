using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Keno.BetType
{
    [RoutePrefix("api/company-win-loss/keno/bet-type")]
    public class KenoBetTypeController : ApiController
    {
        private readonly BetTypeService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public KenoBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService gridOptionService)
        {
            this.winlossService = betTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult Values(BetType.QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new BetType.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(BetType.ExcelModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new BetType.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}