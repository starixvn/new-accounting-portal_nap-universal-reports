namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinor
{
    using Common.BasicWinLoss;
    using Common.ColumnBuilders;
    using System.Web.Http;
    using UniversalReports.CompanyWinLoss.Common;
    using UniversalReports.CompanyWinLoss.Factory;
    using UniversalReports.MVC.Results;

    [RoutePrefix("api/company-win-loss/soccer/major-minor")]
    public class SoccerMajorMinorController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;
        private readonly GridOptionBuilder gridOptionBuilder;

        public SoccerMajorMinorController(
            BasicWinLossService winlossService,
            BasicGridOptionService gridOptionService,
            GridOptionBuilder gridOptionBuilder)
        {
            this.winlossService = winlossService;
            this.gridOptionService = gridOptionService;
            this.gridOptionBuilder = gridOptionBuilder;
        }

        [Route("")]
        public IHttpActionResult SportType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty);
                gridOptions = gridOptionBuilder.BuildVirtualGridOptions(gridOptions, "Major/Minor", 170);

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
                gridOptions = gridOptionBuilder.BuildVirtualGridOptions(gridOptions, "Major/Minor");

                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
