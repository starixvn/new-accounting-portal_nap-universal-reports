using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.HouseWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.NumberGame.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/number-game/bet-type")]
    public class NumberGameBetTypeController : ApiController
    {
        private readonly Service service;
        private readonly BasicGridOptionsBuilder builder;
        private readonly GridOptionColumnDecorator decorator;

        public NumberGameBetTypeController(Service service, BasicGridOptionsBuilder builder, GridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var winlosses = service.Query(criteria);
            var liveBetTypeWinLoss = new BasicWinLossModel
            {
                SiteWinLossSummaries = winlosses.Live,
                GrandTotal = winlosses.LiveGrandTotal,
                RM = new List<Common.Models.WinLoss>()
            };

            var liveGridOptions = builder.Build(liveBetTypeWinLoss, string.Empty);
            liveGridOptions = decorator.Build(liveGridOptions, "Bet Type");

            var nonLiveBetTypeWinLoss = new BasicWinLossModel
            {
                SiteWinLossSummaries = winlosses.NonLive,
                GrandTotal = winlosses.NonLiveGrandTotal,
                RM = new List<Common.Models.WinLoss>()
            };

            var nonLiveGridOptions = builder.Build(nonLiveBetTypeWinLoss, string.Empty);
            nonLiveGridOptions = decorator.Build(nonLiveGridOptions, "Bet Type");

            var result = new JsonResultModel { Live = liveGridOptions, NonLive = nonLiveGridOptions };
            return Json(result);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var winlosses = service.Query(criteria);
            var liveBetTypeWinLoss = new BasicWinLossModel
            {
                SiteWinLossSummaries = winlosses.Live,
                GrandTotal = winlosses.LiveGrandTotal
            };
            var liveGridOptions = builder.Build(liveBetTypeWinLoss, queryModel.LiveTitle);
            liveGridOptions = decorator.Build(liveGridOptions, "Bet Type");

            var nonLiveBetTypeWinLoss = new BasicWinLossModel
            {
                SiteWinLossSummaries = winlosses.NonLive,
                GrandTotal = winlosses.NonLiveGrandTotal
            };

            var nonLiveGridOptions = builder.Build(nonLiveBetTypeWinLoss, queryModel.NonLiveTitle);
            nonLiveGridOptions = decorator.Build(nonLiveGridOptions, "Bet Type");

            return new FanexExcelResult(new List<GridOptions> { nonLiveGridOptions, liveGridOptions }, Constants.SheetName);
        }
    }
}