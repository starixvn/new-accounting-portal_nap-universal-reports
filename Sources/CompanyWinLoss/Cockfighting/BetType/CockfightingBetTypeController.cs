using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Cockfighting.BetType
{
    [RoutePrefix("api/company-win-loss/cock-fighting")]
    public class CockfightingBetTypeController : ApiController
    {
        private readonly BetTypeService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public CockfightingBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService gridOptionService)
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
                    EndDate = queryModel.EndDate
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
