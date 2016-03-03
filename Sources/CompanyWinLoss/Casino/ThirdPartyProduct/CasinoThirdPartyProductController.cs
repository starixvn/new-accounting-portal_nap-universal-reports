using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct
{
    [RoutePrefix("api/company-win-loss/casino")]
    public class CasinoThirdPartyProductController : ApiController
    {
        private readonly ThirdPartyProductService winlossService;
        private readonly ThirdPartyProductGridOptionService gridOptionService;

        public CasinoThirdPartyProductController(
            ThirdPartyProductService thirdPartyProductService,
            ThirdPartyProductGridOptionService thirdPartyProductGridOptionService)
        {
            this.winlossService = thirdPartyProductService;
            this.gridOptionService = thirdPartyProductGridOptionService;
        }

        [Route("third-party-product")]
        public IHttpActionResult ThirdPartyProduct(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate
                };

                var winlosses = this.winlossService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }
    }
}