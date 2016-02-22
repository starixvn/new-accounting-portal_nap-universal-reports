using System.Web.Http;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    [RoutePrefix("api/company-win-loss/number-game")]
    public class NumberGameMatchDetailController : ApiController
    {
        private readonly Service winlossService;
        private readonly GridOptionService gridOptionService;

        public NumberGameMatchDetailController(Service detailService, GridOptionService gridOptionService)
        {
            this.winlossService = detailService;
            this.gridOptionService = gridOptionService;
        }

        [Route("match-detail")]
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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
