using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    [RoutePrefix("api/company-win-loss/soccer/bet-type")]
    public class SoccerBetTypeController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;
        private readonly GridOptionBuilder gridOptionBuilder;

        public SoccerBetTypeController(
            BasicWinLossService winlossService,
            BasicGridOptionService gridOptionService,
            GridOptionBuilder gridOptionBuilder)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
            this.gridOptionBuilder = gridOptionBuilder;
        }

        [Route("")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);
                gridOptions = gridOptionBuilder.BuildVirtualGridOptions(gridOptions, "Bet Type");

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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);
                gridOptions = gridOptionBuilder.BuildVirtualGridOptions(gridOptions, "Bet Type");

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
