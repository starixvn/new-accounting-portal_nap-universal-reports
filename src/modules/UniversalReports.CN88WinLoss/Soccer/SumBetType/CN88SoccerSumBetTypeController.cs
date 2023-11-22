using System.Web.Http;
using AutoMapper;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Configuration;

namespace UniversalReports.CN88WinLoss.Soccer.SumBetType
{
    using Results;

    [RoutePrefix("api/cn88-win-loss-by-products/soccer/sum-bettype")]
    public class CN88SoccerSumBetTypeController : ApiController
    {
        private readonly SumBetTypeWinLossService service;

        private readonly SumBetTypeGridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public CN88SoccerSumBetTypeController(SumBetTypeWinLossService service, SumBetTypeGridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<SumBetTypeCriteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, string.Empty);
            const int mainColumnWidth = 210;
            gridOptions = decorator.Build(gridOptions, "Bet Type", mainColumnWidth);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<SumBetTypeCriteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, queryModel.Title);
            const int mainColumnWidth = 210;
            gridOptions = decorator.Build(gridOptions, "Bet Type", mainColumnWidth);

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}