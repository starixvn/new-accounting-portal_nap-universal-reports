using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    [RoutePrefix("api/company-win-loss/live-casino/third-party-product")]
    public class LiveCasinoThirdPartyProductController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;

        public LiveCasinoThirdPartyProductController(
            BasicWinLossService winlossService,
            BasicGridOptionService thirdPartyProductGridOptionService)
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
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, string.Empty, "3rd Party Product");

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
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, queryModel.Title, "3rd Party Product");
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}