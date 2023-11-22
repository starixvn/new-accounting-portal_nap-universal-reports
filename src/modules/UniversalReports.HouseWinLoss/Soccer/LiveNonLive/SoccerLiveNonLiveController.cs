using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.Soccer.LiveNonLive
{
    using Results;

    [RoutePrefix("api/house-win-loss-by-products/soccer/live-nonlive")]
    public class SoccerLiveNonLiveController : ApiController
    {
        private readonly SoccerLiveNonLiveWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public SoccerLiveNonLiveController(
            SoccerLiveNonLiveWinLossService service,
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

        private IEnumerable<GridOptions> BuildGridOptions(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = service.Query(criteria).ToArray();

            var majorMinorGridOptions = builder.Build(winlosses.First(), "Major/Minor");
            yield return decorator.Build(majorMinorGridOptions, "Major/Minor");

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), "Live/Non-Live");
            yield return decorator.Build(liveNonLiveGridOptions, "Live/Non-Live");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = service.Query(criteria).ToArray();

            var majorMinorGridOptions = builder.Build(winlosses.First(), queryModel.MajorMinorTitle);
            majorMinorGridOptions = decorator.Build(majorMinorGridOptions, "Major/Minor");

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), queryModel.LiveNonLiveTitle);
            liveNonLiveGridOptions = decorator.Build(liveNonLiveGridOptions, "Live/Non-Live");

            return new FanexExcelResult(
                new List<GridOptions> { majorMinorGridOptions, liveNonLiveGridOptions },
                Constants.SheetName);
        }
    }
}