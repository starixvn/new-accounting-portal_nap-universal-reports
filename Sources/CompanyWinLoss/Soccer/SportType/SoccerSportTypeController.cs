using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.Soccer.SportType
{
    [RoutePrefix("api/company-win-loss/soccer/sporttype")]
    public class SoccerSportTypeController : BasicWinLossController
    {
        public SoccerSportTypeController(
           BasicWinLossService service,
           BasicGridOptionBuilder builder,
           GridOptionColumnDecoratorVirtual decorator)
        : base(service, builder, decorator)
        {
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var majorMinorCriteria = CriteriaFactory.Transform<MajorMinor.Criteria>(queryModel);
            var majorMinorGridOptions = GetGridOptions(majorMinorCriteria, "Sport Type", queryModel.MajorMinorTitle);

            var liveNonLiveCriteria = CriteriaFactory.Transform<LiveNonLive.Criteria>(queryModel);
            var liveNonLiveGridOptions = GetGridOptions(liveNonLiveCriteria, "Sport Type", queryModel.LiveNonLiveTitle);

            return new FanexExcelResult(new List<GridOptions> { majorMinorGridOptions, liveNonLiveGridOptions }, Constants.SheetName);
        }
    }
}
