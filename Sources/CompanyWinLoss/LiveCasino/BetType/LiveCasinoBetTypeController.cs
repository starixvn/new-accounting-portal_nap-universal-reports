using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoBetTypeController : ApiController
    {
        private readonly BetTypeService _betTypeService;
        private readonly BetTypeGridOptionService _betTypeGridOptionService;

        public LiveCasinoBetTypeController(BetTypeService betTypeService, BetTypeGridOptionService betTypeGridOptionService)
        {
            _betTypeService = betTypeService;
            _betTypeGridOptionService = betTypeGridOptionService;
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

                var bettypes = _betTypeService.Query(criteria);
                var gridOptions = _betTypeGridOptionService.FromBetTypeWinLoss(bettypes, queryModel.BreadCumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
