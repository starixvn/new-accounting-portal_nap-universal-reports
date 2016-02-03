using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using gameType = UniversalReports.CompanyWinLoss.LiveCasino.GameType;
using thirdPartyProduct = UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct;

namespace UniversalReports.CompanyWinLoss.LiveCasino
{
    public class LiveCasinoController : ApiController
    {
        private thirdPartyProduct.Service _sumamaryService;
        private gameType.Service _productDetailService;
        private readonly SiteService _siteService;

        public LiveCasinoController(
            thirdPartyProduct.Service summaryService,
            gameType.Service productDetailService,
            SiteService siteService)
        {
            _sumamaryService = summaryService;
            _productDetailService = productDetailService;
            _siteService = siteService;
        }

        public thirdPartyProduct.WinLossModel ThirdPartyProduct(thirdPartyProduct.QueryModel queryModel)
        {
            var criteria = new thirdPartyProduct.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid 
                ? _sumamaryService.Query(criteria) 
                : null;
        }

        public gameType.WinLossModel GameType(gameType.QueryModel queryModel)
        {
            var criteria = new gameType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                ProductId = queryModel.ProductId
            };

            return ModelState.IsValid
                ? _productDetailService.Query(criteria)
                : null;
        }

        [Route("site")]
        public SiteWinLoss Site(Site.QueryModel queryModel)
        {
            var criteria = new Site.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                BetType = queryModel.BetType,
                Site = queryModel.Site
            };

            return ModelState.IsValid
                ? _siteService.Query(criteria)
                : null;
        }
    }
}
