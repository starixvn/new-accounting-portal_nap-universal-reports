using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Keno
{
    [RoutePrefix("api/company-win-loss/keno")]
    public class BetTypeController : ApiController
    {
        private readonly BetTypeService betTypeService;

        public BetTypeController(BetTypeService betTypeService)
        {
            this.betTypeService = betTypeService;
        }

        [Route("bet-type")]
        public BetTypeWinLossModel Values(BetType.QueryModel queryModel)
        {
            var criteria = new BetType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid
                ? betTypeService.Query(criteria)
                : null;
        }
    }
}
