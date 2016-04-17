using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    [RoutePrefix("api/company-win-loss/number-game/bet-type")]
    public class NumberGameBetTypeController : ApiController
    {
        private readonly Service service;
        private readonly BasicGridOptionBuilder builder;
        private readonly GridOptionColumnDecorator decorator;

        public NumberGameBetTypeController(Service service, BasicGridOptionBuilder builder, GridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            if (ModelState.IsValid)
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

                return Json(new { Live = liveGridOptions, NonLive = nonLiveGridOptions });
            }

            return null;
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            if (ModelState.IsValid)
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

            return null;
        }
    }
}