using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Universal.BetType
{
    [RoutePrefix("api/house-win-loss-by-products/universal")]
    public class UniversalBetTypeController : BasicWinLossController
    {
        public UniversalBetTypeController(BasicWinLossService service, BasicGridOptionsBuilder builder, GridOptionColumnDecoratorBasic decorator)
         : base(service, builder, decorator)
        {
        }

        [Route("bet-type")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Json(criteria, "Bet Type");
        }

        [Route("bet-type/excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            return Excel(criteria, "Bet Type", queryModel.Title);
        }

        [Route("bet-type-live-non-live/excel")]
        public async Task<IHttpActionResult> ExcelLiveNonLive(ExcelLiveNonLiveQueryModel queryModel)
        {
            var criteria = Mapper.Map<Criteria>(queryModel);
            var winlosses = await QueryLiveNonLiveBetType(criteria).ConfigureAwait(false);

            var nonLiveGridOptions = Builder.Build(winlosses[0], queryModel.NonLiveTitle);
            nonLiveGridOptions = Decorator.Build(nonLiveGridOptions, "Bet Type");

            var liveGridOptions = Builder.Build(winlosses[1], queryModel.LiveTitle);
            liveGridOptions = Decorator.Build(liveGridOptions, "Bet Type");

            return new FanexExcelResult(new List<GridOptions> { nonLiveGridOptions, liveGridOptions }, Constants.SheetName);
        }

        private async Task<BasicWinLossModel[]> QueryLiveNonLiveBetType(Criteria criteria)
        {
            var liveCriteria = criteria.Clone();
            liveCriteria.IsLive = 1;

            var nonLiveCriteria = criteria.Clone();
            nonLiveCriteria.IsLive = 0;

            var tasks = new[]
            {
                 Task.Run(() => Service.Query(nonLiveCriteria)),
                 Task.Run(() => Service.Query(liveCriteria))
            };

            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}