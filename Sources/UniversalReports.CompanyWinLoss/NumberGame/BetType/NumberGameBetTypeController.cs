using Fanex.Excel.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.ColumnDecorators;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.MVC.Results;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    [RoutePrefix("api/company-win-loss/number-game/bet-type")]
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

            var result = Json(new { Live = liveGridOptions, NonLive = nonLiveGridOptions });
            var fileName = queryModel.GetType().FullName;
            var criteriaFileName = "D:\\" + fileName + "-queryModel.json";
            var liveresultFileName = "D:\\" + fileName + "-expected-live.json";
            var nonliveresultFileName = "D:\\" + fileName + "-expected-non-live.json";
            var json = JsonConvert.SerializeObject(queryModel, Formatting.Indented);
            System.IO.File.WriteAllText(criteriaFileName, json);
            json = JsonConvert.SerializeObject(liveGridOptions, Formatting.Indented);
            System.IO.File.WriteAllText(liveresultFileName, json);
            json = JsonConvert.SerializeObject(nonLiveGridOptions, Formatting.Indented);
            System.IO.File.WriteAllText(nonliveresultFileName, json);
            return result;
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