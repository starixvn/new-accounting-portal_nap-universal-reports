using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoThirdPartyProductController : ApiController
    {
        private readonly ThirdPartyProductService thirdPartyProductService;
        private readonly ThirdPartyProductGridOptionService thirdPartyProductGridOptionService;

        public LiveCasinoThirdPartyProductController(
            ThirdPartyProductService thirdPartyProductService,
            ThirdPartyProductGridOptionService thirdPartyProductGridOptionService)
        {
            this.thirdPartyProductService = thirdPartyProductService;
            this.thirdPartyProductGridOptionService = thirdPartyProductGridOptionService;
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

                var products = this.thirdPartyProductService.Query(criteria);
                var gridOptions = this.thirdPartyProductGridOptionService.FromProductWinLoss(products, queryModel.BreadCrumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
