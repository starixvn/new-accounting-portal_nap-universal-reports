using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.BetType
{
    [RoutePrefix("api/company-win-loss/virtual-sports")]
    public class VirtualSportsBetTypeController : ApiController
    {
        private readonly BetTypeService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public VirtualSportsBetTypeController(
            BetTypeGridOptionService gridOptionService,
            BetTypeService betTypeService)
        {
            this.gridOptionService = gridOptionService;
            this.winlossService = betTypeService;
        }

        [Route("bet-type")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new BetType.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate,
                    SportType = queryModel.SportType
                };

                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
