using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.OtherSports.LiveNonLive
{
    [RoutePrefix("api/company-win-loss/other-sports/live-non-live")]
    public class OtherSportsLiveNonLiveController : BasicWinLossController
    {
        public OtherSportsLiveNonLiveController(
            BasicWinLossService service,
            BasicGridOptionBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            return Json(criteria, "Live/Non-Live");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
            {
                var sportTypeCriteria = CriteriaFactory.Transform<SportType.Criteria>(queryModel);
                var sportTypeGridOptions = GetGridOptions(sportTypeCriteria, "Sport Type");

                var liveNonLiveCriteria = CriteriaFactory.Transform<Criteria>(queryModel);
                var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Live/Non-Live", queryModel.LiveNonLiveTitle);

                return new FanexExcelResult(new List<GridOptions> { sportTypeGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
            }

            return null;
        }
    }
}