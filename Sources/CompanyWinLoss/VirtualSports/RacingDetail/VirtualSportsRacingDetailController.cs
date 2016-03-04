using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    [RoutePrefix("api/company-win-loss/virtual-sports/racing-match-detail")]
    public class VirtualSportsRacingDetailController : ApiController
    {
        private readonly Service winlossService;

        private readonly GridOptionService gridOptionService;

        public VirtualSportsRacingDetailController(Service racingService, GridOptionService gridOptionService)
        {
            this.winlossService = racingService;
            this.gridOptionService = gridOptionService;
        }

        [Route("")]
        public IHttpActionResult RacingDetail(QueryModel queryModel)
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