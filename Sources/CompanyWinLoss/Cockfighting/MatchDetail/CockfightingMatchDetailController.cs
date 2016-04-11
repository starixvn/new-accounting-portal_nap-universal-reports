using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    [RoutePrefix("api/company-win-loss/cockfighting/match-detail")]
    public class CockfightingMatchDetailController : ApiController
    {
        private readonly MatchDetailWinLossService winlossService;
        private readonly GridOptionService gridOptionService;

        public CockfightingMatchDetailController(MatchDetailWinLossService winlossService, GridOptionService gridOptionService)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult MatchDetail(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);

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
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}