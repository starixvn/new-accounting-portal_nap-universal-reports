namespace UniversalReports.CompanyWinLoss.Soccer.MajorMinorSportTypes
{
    using Common.BasicWinLoss;
    using System.Web.Http;
    using UniversalReports.CompanyWinLoss.Common;
    using UniversalReports.CompanyWinLoss.Factory;
    using UniversalReports.MVC.Results;

    [RoutePrefix("api/company-win-loss/soccer/major-minor")]
    public class SoccerMajorAndMinorSportTypesController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;

        public SoccerMajorAndMinorSportTypesController(BasicWinLossService winlossService, BasicGridOptionService gridOptionService)
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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, string.Empty, "Sport Type");

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
                var gridOptions = gridOptionService.FromWinLossModel(winlosses, queryModel.Title, "Sport Type");
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
