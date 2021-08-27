using AutoMapper;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.CashOut.LiveNonLive
{
    [RoutePrefix("api/house-win-loss-by-products/cash-out/live-non-live")]
    public class CashOutLiveNonLiveController : ApiController
    {
        private readonly CashOutLiveNonLiveWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public CashOutLiveNonLiveController(
            CashOutLiveNonLiveWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorBasic decorator)
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

        private IEnumerable<GridOptions> BuildGridOptions(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = service.Query(criteria).ToArray();

            var majorMinorGridOptions = builder.Build(winlosses.First(), "Sport Type");
            const int mainColumnWidth = 220;
            yield return decorator.Build(majorMinorGridOptions, "Sport Type", mainColumnWidth);

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), "Live/Non-Live");
            yield return decorator.Build(liveNonLiveGridOptions, "Live/Non-Live", mainColumnWidth);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
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
    }
}