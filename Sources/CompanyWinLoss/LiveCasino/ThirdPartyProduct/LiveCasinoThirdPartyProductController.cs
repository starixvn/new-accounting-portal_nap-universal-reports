using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    [RoutePrefix("api/company-win-loss/live-casino/third-party-product")]
    public class LiveCasinoThirdPartyProductController : ApiController
    {
        private readonly ReportWinLossService winlossService;
        private readonly ThirdPartyProductGridOptionService gridOptionService;

        public LiveCasinoThirdPartyProductController(
            ReportWinLossService winlossService,
            ThirdPartyProductGridOptionService thirdPartyProductGridOptionService)
        {
            this.winlossService = winlossService;
            this.gridOptionService = thirdPartyProductGridOptionService;
        }

        [Route("")]
        public IHttpActionResult ThirdPartyProduct(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = this.winlossService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = this.winlossService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}