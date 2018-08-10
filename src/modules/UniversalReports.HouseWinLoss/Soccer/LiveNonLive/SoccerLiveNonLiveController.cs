using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Soccer.LiveNonLive
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/live-nonlive")]
    public class SoccerLiveNonLiveController : ApiController
    {
        private readonly SoccerLiveNonLiveWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public SoccerLiveNonLiveController(
            SoccerLiveNonLiveWinLossService service,
            BasicGridOptionsBuilder builder,
            GridOptionColumnDecoratorVirtual decorator)
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
            var winlosses = service.Query(criteria);

            var majorMinorGridOptions = builder.Build(winlosses.First(), "Major/Minor");
            yield return decorator.Build(majorMinorGridOptions, "Major/Minor");

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), "Live/Non-Live");
            yield return decorator.Build(liveNonLiveGridOptions, "Live/Non-Live");
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = service.Query(criteria);

            var majorMinorGridOptions = builder.Build(winlosses.First(), "Major/Minor");
            majorMinorGridOptions = decorator.Build(majorMinorGridOptions, queryModel.MajorMinorTitle);

            var liveNonLiveGridOptions = builder.Build(winlosses.Last(), "Live/Non-Live");
            liveNonLiveGridOptions = decorator.Build(liveNonLiveGridOptions, queryModel.LiveNonLiveTitle);

            return new FanexExcelResult(
                new List<GridOptions> { majorMinorGridOptions, liveNonLiveGridOptions },
                Constants.SheetName);
        }
    }
}