using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Racing.SportType
{
    [RoutePrefix("api/company-win-loss/racing/sport-type")]
    public class RacingSportTypeController : ApiController
    {
        private readonly SportTypeService sportTypeService;
        private readonly SportTypeGridOptionService gridOptionService;

        public RacingSportTypeController(SportTypeService sportTypeService, SportTypeGridOptionService gridOptionService)
        {
            this.sportTypeService = sportTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult SportType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new SportType.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate
                };

                var winlosses = this.sportTypeService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, string.Empty);

                return Json(gridOptions);
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = new SportType.Criteria
                {
                    StartDate = queryModel.StartDate,
                    EndDate = queryModel.EndDate
                };

                var winlosses = this.sportTypeService.Query(criteria);
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, queryModel.Title);
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}