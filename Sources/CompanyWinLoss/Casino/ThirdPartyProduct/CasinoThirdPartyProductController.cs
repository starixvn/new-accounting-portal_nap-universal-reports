using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Casino.ThirdPartyProduct
{
    [RoutePrefix("api/company-win-loss/casino/third-party-product")]
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

        [Route("")]
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
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate
                };

                var winlosses = this.winlossService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}