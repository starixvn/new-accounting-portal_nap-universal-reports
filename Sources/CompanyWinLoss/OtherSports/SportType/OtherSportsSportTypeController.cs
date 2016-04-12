using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.OtherSports.SportType
{
    [RoutePrefix("api/company-win-loss/other-sports/sport-type")]
    public class OtherSportsSportTypeController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BasicGridOptionService gridOptionService;

        public OtherSportsSportTypeController(BasicWinLossService winlossService, BasicGridOptionService gridOptionService)
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
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, string.Empty, "Sport Type");

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
                var gridOptions = this.gridOptionService.FromWinLossModel(winlosses, queryModel.Title, "Sport Type");
                return new FanexExcelResult(gridOptions, Constants.SheetName);
            }

            return null;
        }
    }
}
