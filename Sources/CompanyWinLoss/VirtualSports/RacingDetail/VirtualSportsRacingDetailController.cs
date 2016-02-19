using System.Web.Http;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    [RoutePrefix("api/company-win-loss/virtual-sports")]
    public class VirtualSportsRacingDetailController : ApiController
    {
        private readonly Service winlossService;

        private readonly GridOptionService gridOptionService;

        public VirtualSportsRacingDetailController(Service racingService, GridOptionService gridOptionService)
        {
            this.winlossService = racingService;
            this.gridOptionService = gridOptionService;
        }

        [Route("racing-match-detail")]
        public IHttpActionResult RacingDetail(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new RacingDetail.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    SportType = queryModel.SportType,
                    BetType = queryModel.BetType
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
