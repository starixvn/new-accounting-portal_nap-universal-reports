using System.Web.Http;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    [RoutePrefix("api/company-win-loss/cock-fighting")]
    public class CockfightingMatchDetailController : ApiController
    {
        private readonly Service service;
        private readonly GridOptionService gridOptionService;

        public CockfightingMatchDetailController(Service service, GridOptionService gridOptionService)
        {
            this.service = service;
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
                    EndDate = queryModel.EndDate
                };

                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }
    }
}