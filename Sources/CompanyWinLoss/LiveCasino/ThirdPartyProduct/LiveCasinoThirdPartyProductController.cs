using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoThirdPartyProductController : ApiController
    {
        private readonly ThirdPartyProductService _thirdPartyProductService;
        private readonly ThirdPartyProductGridOptionService _thirdPartyProductGridOptionService;

        public LiveCasinoThirdPartyProductController(
            ThirdPartyProductService thirdPartyProductService,
            ThirdPartyProductGridOptionService thirdPartyProductGridOptionService)
        {
            _thirdPartyProductService = thirdPartyProductService;
            _thirdPartyProductGridOptionService = thirdPartyProductGridOptionService;
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

                var products = _thirdPartyProductService.Query(criteria);
                var gridOptions = _thirdPartyProductGridOptionService.FromProductWinLoss(products, queryModel.BreadCumb);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
