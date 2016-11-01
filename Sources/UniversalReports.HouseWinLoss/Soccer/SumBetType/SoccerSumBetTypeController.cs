using System.Web.Http;
using UniversalReports.Core.Factory;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/sum-bettype")]
    public class SoccerSumBetTypeController : ApiController
    {
        private readonly WinLossService service;

        private readonly GridOptionsBuilder builder;

        private readonly GridOptionColumnDecorator decorator;

        public SoccerSumBetTypeController(WinLossService service, GridOptionsBuilder builder, GridOptionColumnDecoratorVirtual decorator)
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
            var gridOptions = builder.FromWinLossModel(winlosses, string.Empty);
            gridOptions = decorator.Build(gridOptions, "Bet Type");

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = CriteriaFactory.Transform<Criteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.FromWinLossModel(winlosses, queryModel.Title);
            gridOptions = decorator.Build(gridOptions, "Bet Type");

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}