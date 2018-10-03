using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.SportType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/sport-type")]
    public class SoccerMinorSportTypeController : BasicWinLossController
    {
        public SoccerMinorSportTypeController(BasicWinLossService service, BasicGridOptionsBuilder builder, GridOptionColumnDecoratorVirtual decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Sport Type");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var gridOptions = GetGridOptions(criteria, "Sport Type", queryModel.Title);
            return new FanexExcelResult(gridOptions, Constants.SoccerMinorBetTypesSheetName);
        }
    }
}