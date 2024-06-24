using AutoMapper;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.Results;

namespace UniversalReports.HouseWinLoss.BetBuilder.SportType
{
    [RoutePrefix("api/house-win-loss-by-products/bet-builder/sport-type")]
    public class BetBuilderSportTypeController : ApiController
    {
        private readonly BetBuilderSportTypeWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;
        public BetBuilderSportTypeController(
            BetBuilderSportTypeWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var gridOptions = BuildGridOptions(queryModel);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalSecondLevelCriteria>(queryModel);
            var winlosses = service.Query(criteria).ToArray();

            var majorMinorGridOptions = builder.Build(winlosses.First(), queryModel.BetTypeTitle);
            const int mainColumnWidth = 220;
            majorMinorGridOptions = decorator.Build(majorMinorGridOptions, "Sport Type", mainColumnWidth);

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), queryModel.LiveNonLiveTitle);
            liveNonLiveGridOptions = decorator.Build(liveNonLiveGridOptions, "Live/Non-Live", mainColumnWidth);

            return new FanexExcelResult(
                new List<GridOptions> { majorMinorGridOptions, liveNonLiveGridOptions },
                Constants.SheetName);
        }

        private IEnumerable<GridOptions> BuildGridOptions(QueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalSecondLevelCriteria>(queryModel);
            var winlosses = service.Query(criteria).ToArray();

            var majorMinorGridOptions = builder.Build(winlosses.First(), "Sport Type");
            const int mainColumnWidth = 220;
            yield return decorator.Build(majorMinorGridOptions, "Sport Type", mainColumnWidth);

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), "Live/Non-Live");
            yield return decorator.Build(liveNonLiveGridOptions, "Live/Non-Live", mainColumnWidth);
        }
    }
}