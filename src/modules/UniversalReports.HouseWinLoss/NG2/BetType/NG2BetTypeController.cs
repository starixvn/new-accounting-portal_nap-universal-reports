using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.NG2.BetType
{
    public class NG2BetTypeController : ApiController
    {
        private readonly BasicWinLossService service;

        private readonly BasicGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public NG2BetTypeController(
           BasicWinLossService service,
           BasicGridOptionsBuilder builder,
           GridOptionColumnDecorator decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("api/house-win-loss-by-products/ng2-live-non-live/excel")]
        public async Task<IHttpActionResult> ExcelLiveNonLive(ExcelLiveNonLiveQueryModel queryModel)
        {
            var criteria = Mapper.Map<UniversalBetTypeCriteria>(queryModel);
            var winlosses = await QueryLiveNonLiveBetType(criteria).ConfigureAwait(false);

            var nonLiveGridOptions = builder.Build(winlosses[0], queryModel.NonLiveTitle);
            nonLiveGridOptions = decorator.Build(nonLiveGridOptions, "Bet Type");

            var liveGridOptions = builder.Build(winlosses[1], queryModel.LiveTitle);
            liveGridOptions = decorator.Build(liveGridOptions, "Bet Type");

            return new FanexExcelResult(new List<GridOptions> { nonLiveGridOptions, liveGridOptions }, Constants.SheetName);
        }

        private async Task<BasicWinLossModel[]> QueryLiveNonLiveBetType(UniversalBetTypeCriteria criteria)
        {
            var liveCriteria = criteria.Clone();
            liveCriteria.IsLive = 1;

            var nonLiveCriteria = criteria.Clone();
            nonLiveCriteria.IsLive = 0;

            var tasks = new[]
            {
                 Task.Run(() => service.Query(nonLiveCriteria)),
                 Task.Run(() => service.Query(liveCriteria))
            };

            return await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}