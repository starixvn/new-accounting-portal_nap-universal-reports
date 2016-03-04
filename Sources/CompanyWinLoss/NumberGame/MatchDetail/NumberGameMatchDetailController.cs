using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    [RoutePrefix("api/company-win-loss/number-game/match-detail")]
    public class NumberGameMatchDetailController : ApiController
    {
        private readonly Service winlossService;
        private readonly GridOptionService gridOptionService;

        public NumberGameMatchDetailController(Service detailService, GridOptionService gridOptionService)
        {
            this.winlossService = detailService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult MatchDetail(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    BetType = queryModel.BetType,
                    IsLive = queryModel.IsLive,
                    SportType = queryModel.SportType
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
                    BetType = queryModel.BetType,
                    IsLive = queryModel.IsLive,
                    SportType = queryModel.SportType
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}