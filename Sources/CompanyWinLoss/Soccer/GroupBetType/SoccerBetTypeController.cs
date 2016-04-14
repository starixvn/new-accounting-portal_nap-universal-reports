using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.CompanyWinLoss.Soccer.BetType;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    [RoutePrefix("api/company-win-loss/soccer/major-or-minor-bettypes")]
    public class SoccerBetTypeController : ApiController
    {
        private readonly WinLossService winlossService;
        private readonly BetTypesGridOptionService gridOptionService;

        public SoccerBetTypeController(WinLossService winlossService, BetTypesGridOptionService gridOptionService)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult SportType(QueryModel queryModel)
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
