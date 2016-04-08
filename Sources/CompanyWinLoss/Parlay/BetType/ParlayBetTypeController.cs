using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Parlay.BetType
{
    [RoutePrefix("api/company-win-loss/parlay/bet-type")]
    public class ParlayBetTypeController : ApiController
    {
        private readonly ReportWinLossService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public ParlayBetTypeController(BetTypeGridOptionService gridOptionService, ReportWinLossService winlossService)
        {
            this.gridOptionService = gridOptionService;
            this.winlossService = winlossService;
        }

        [Route("")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winloss = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winloss, string.Empty);
                return Json(gridOptions);
            }
            return null;

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
