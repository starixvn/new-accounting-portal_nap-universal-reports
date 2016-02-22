using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportType
{
    [RoutePrefix("api/company-win-loss/virtual-sports")]
    public class VirtualSportsSportTypeController : ApiController
    {
        private readonly SportTypeService sportTypeService;
        private readonly SportTypeGridOptionService gridOptionService;

        public VirtualSportsSportTypeController(SportTypeService sportTypeService, SportTypeGridOptionService gridOptionService)
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
