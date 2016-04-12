namespace UniversalReports.CompanyWinLoss.Soccer.LiveNonLiveSportTypes
{
    using Common.BasicWinLoss;
    using GridOption;
    using System.Web.Http;
    using UniversalReports.CompanyWinLoss.Common;
    using UniversalReports.CompanyWinLoss.Factory;
    using UniversalReports.MVC.Results;

    [RoutePrefix("api/company-win-loss/soccer/live-and-nonlive-sport-types")]
    class SoccerLiveAndNonLiveSportTypesController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly SportTypesGridOptionService gridOptionService;

        public SoccerLiveAndNonLiveSportTypesController(BasicWinLossService winlossService, SportTypesGridOptionService gridOptionService)
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
