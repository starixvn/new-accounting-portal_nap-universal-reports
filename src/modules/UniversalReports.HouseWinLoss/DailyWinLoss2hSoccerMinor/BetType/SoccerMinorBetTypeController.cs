using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/bet-type")]
    public class SoccerMinorBetTypeController : BasicWinLossController
    {
        public SoccerMinorBetTypeController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Bet Type", 210);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            criteria.IsLive = 2;
            var sumGridOption = GetGridOptions(criteria, "Bet Type", queryModel.BetTypeFullTitle, 210);

            criteria.IsLive = 1;
            var liveGridOption = GetGridOptions(criteria, "Bet Type", queryModel.BetTypeLiveTitle, 210);

            criteria.IsLive = 0;
            var noneLiveGridOption = GetGridOptions(criteria, "Bet Type", queryModel.BetTypeLiveTitle, 210);

            return new FanexExcelResult(
                new List<GridOptions> { sumGridOption, liveGridOption, noneLiveGridOption },
                Constants.SheetName);
        }
    }
}