using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoBetTypeController : ApiController
    {
        private readonly BetTypeService betTypeService;
        private readonly BetTypeGridOptionService betTypeGridOptionService;

        public LiveCasinoBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService betTypeGridOptionService)
        {
            this.betTypeService = betTypeService;
            this.betTypeGridOptionService = betTypeGridOptionService;
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

                var bettypes = this.betTypeService.Query(criteria);
                var gridOptions = this.betTypeGridOptionService.FromBetTypeWinLoss(bettypes, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
