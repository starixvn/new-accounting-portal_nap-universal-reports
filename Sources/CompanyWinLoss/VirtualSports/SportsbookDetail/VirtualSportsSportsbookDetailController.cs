using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    [RoutePrefix("api/company-win-loss/virtual-sports")]
    public class VirtualSportsSportsbookDetailController : ApiController
    {
        private readonly Service winlossService;

        private GridOptionService gridOptionService;

        public VirtualSportsSportsbookDetailController(Service sportsbookService, GridOptionService gridOptionService)
        {
            this.winlossService = sportsbookService;
            this.gridOptionService = gridOptionService;
        }

        [Route("sportsbook-match-detail")]
        public IHttpActionResult SportsbookDetail(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new SportsbookDetail.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    SportType = queryModel.SportType,
                    BetType = queryModel.BetType
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("sportsbook-match-detail/excel")]
        public IHttpActionResult Excel(ExcelModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new SportsbookDetail.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    SportType = queryModel.SportType,
                    BetType = queryModel.BetType
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}