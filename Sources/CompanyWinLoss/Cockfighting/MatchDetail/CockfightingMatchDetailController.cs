using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    [RoutePrefix("api/company-win-loss/cockfighting/match-detail")]
    public class CockfightingMatchDetailController : ApiController
    {
        private readonly Service service;
        private readonly GridOptionService gridOptionService;

        public CockfightingMatchDetailController(Service service, GridOptionService gridOptionService)
        {
            this.service = service;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult MatchDetail(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = service.Query(criteria);
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
                var winlosses = service.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}