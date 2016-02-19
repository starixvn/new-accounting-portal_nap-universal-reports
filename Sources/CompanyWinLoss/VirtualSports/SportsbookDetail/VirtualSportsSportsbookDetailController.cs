using System.Web.Http;

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

        [Route("sports-book-match-detail")]
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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
