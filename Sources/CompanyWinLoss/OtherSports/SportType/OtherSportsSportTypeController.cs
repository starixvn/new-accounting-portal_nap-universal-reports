using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;


namespace UniversalReports.CompanyWinLoss.OtherSports.SportType
{
    [RoutePrefix("api/company-win-loss/other-sports/sport-type")]
    public class OtherSportsSportTypeController : ApiController
    {
        private readonly SportTypeService sportTypeService;
        private readonly SportTypeGridOptionService gridOptionService;

        public OtherSportsSportTypeController (SportTypeService sportTypeService, SportTypeGridOptionService gridOptionService)
        {
            this.sportTypeService = sportTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult SportType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = this.sportTypeService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }
            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel (ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winlosses = this.sportTypeService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }
            return null;
        }
    }
}
