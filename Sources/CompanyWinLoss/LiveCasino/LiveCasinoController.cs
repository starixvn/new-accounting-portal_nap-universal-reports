using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using betType = UniversalReports.CompanyWinLoss.LiveCasino.BetType;
using thirdPartyProduct = UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct;

namespace UniversalReports.CompanyWinLoss.LiveCasino
{
    [RoutePrefix("api/company-win-loss/live-casino")]
    public class LiveCasinoController : ApiController
    {
        private thirdPartyProduct.Service _thirdPartyProductService;
        private betType.Service _betTypeService;
        private readonly SiteService _siteService;

        public LiveCasinoController(
            thirdPartyProduct.Service thirdPartyProductService,
            betType.Service betTypeService,
            SiteService siteService)
        {
            _thirdPartyProductService = thirdPartyProductService;
            _betTypeService = betTypeService;
            _siteService = siteService;
        }

        [Route("third-party-product")]
        public thirdPartyProduct.WinLossModel ThirdPartyProduct(thirdPartyProduct.QueryModel queryModel)
        {
            var criteria = new thirdPartyProduct.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid 
                ? _thirdPartyProductService.Query(criteria) 
                : null;
        }

        [Route("bet-type")]
        public betType.WinLossModel BetType(betType.QueryModel queryModel)
        {
            var criteria = new betType.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                ProductId = queryModel.ProductId
            };

            return ModelState.IsValid
                ? _betTypeService.Query(criteria)
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
