using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.OtherSports.BetType
{
    [RoutePrefix("api/company-win-loss/other-sports/bet-type")]
    public class OtherSportsBetTypeController : ApiController
    {
        private readonly BasicWinLossService winlossService;
        private readonly BetTypeGridOptionService gridOptionService;

        public OtherSportsBetTypeController(BasicWinLossService winlossService, BetTypeGridOptionService gridOptionService)
        {
            this.gridOptionService = gridOptionService;
            this.winlossService = winlossService;
        }

        [Route("")]
        public IHttpActionResult BetType(QueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var winloss = winlossService.Query(criteria);
                var gridOptions = gridOptionService.FromWinLossModel(winloss, string.Empty);
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
