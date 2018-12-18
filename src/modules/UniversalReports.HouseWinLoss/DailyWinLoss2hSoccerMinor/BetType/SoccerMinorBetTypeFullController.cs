using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.DailyWinLoss2hSoccerMinor.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer-minor/bet-type-full")]
    public class SoccerMinorBetTypeFullController : ApiController
    {
        private readonly BasicWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecoratorVirtual decorator;

        public SoccerMinorBetTypeFullController(
            BasicWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<SoccerMinor2hBetTypeCriteria>(queryModel);
            criteria.IsLive = 2;
            var sumGridOption = GetGridOptions(criteria, queryModel.BetTypeFullTitle);

            criteria.IsLive = 1;
            var liveGridOption = GetGridOptions(criteria, queryModel.BetTypeLiveTitle);

            criteria.IsLive = 0;
            var noneLiveGridOption = GetGridOptions(criteria, queryModel.BetTypeLiveTitle);

            return new FanexExcelResult(
                new List<GridOptions> { sumGridOption, liveGridOption, noneLiveGridOption },
                Constants.SoccerMinorBetTypesSheetName);
        }

        private GridOptions GetGridOptions(WinLossCriteria criteria, string title)
        {
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, title);
            return decorator.Build(gridOptions, "Bet Type", 210);
        }
    }
}
