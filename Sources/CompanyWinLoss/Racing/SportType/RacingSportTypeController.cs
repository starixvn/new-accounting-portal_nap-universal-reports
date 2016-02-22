using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Racing.SportType
{
    [RoutePrefix("api/company-win-loss/racing")]
    public class RacingSportTypeController : ApiController
    {
        private readonly SportTypeService sportTypeService;
        private readonly SportTypeGridOptionService gridOptionService;

        public RacingSportTypeController(SportTypeService sportTypeService, SportTypeGridOptionService gridOptionService)
        {
            this.sportTypeService = sportTypeService;
            this.gridOptionService = gridOptionService;
        }

        [Route("sport-type")]
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
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses);

                return Json(gridOptions);
            }

            return null;
        }
    }
}
