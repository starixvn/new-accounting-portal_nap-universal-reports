using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Factory;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    [RoutePrefix("api/company-win-loss/number-game")]
    public class NumberGameBetTypeController : ApiController
    {
        private readonly Service winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public NumberGameBetTypeController(Service betTypeService, BetTypeGridOptionService gridOptionService)
        {
            this.winlossService = betTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("bet-type")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var liveBetTypeWinLoss = new BetTypeWinLossModel
                {
                    BetTypes = winlosses.Live,
                    GrandTotal = winlosses.LiveGrandTotal
                };
                var liveGridOptions = gridOptionService.FromWinLossModel(liveBetTypeWinLoss, string.Empty);

                var nonLiveBetTypeWinLoss = new BetTypeWinLossModel
                {
                    BetTypes = winlosses.NonLive,
                    GrandTotal = winlosses.NonLiveGrandTotal
                };

                var nonLiveGridOptions = gridOptionService.FromWinLossModel(nonLiveBetTypeWinLoss, string.Empty);

                return Json(new { Live = liveGridOptions, NonLive = nonLiveGridOptions });
            }

            return null;
        }
    }
}