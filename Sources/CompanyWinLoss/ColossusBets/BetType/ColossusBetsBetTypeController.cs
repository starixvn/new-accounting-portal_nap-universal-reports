using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.ColossusBets.BetType
{
    [RoutePrefix("api/company-win-loss/colossus-bets")]
    public class ColossusBetsBetTypeController : ApiController
    {
        private readonly BetTypeService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public ColossusBetsBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService gridOptionService)
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
    }
}
