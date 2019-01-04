using System.Web.Http;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Configuration;
using UniversalReports.MVC.Results;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    [RoutePrefix("api/house-win-loss-by-products/soccer/group-bettype")]
    public class SoccerGroupBetTypeController : ApiController
    {
        private readonly GroupBetTypeWinLossService service;
        private readonly GroupBetTypeGridOptionsBuilder builder;
        private readonly GridOptionColumnDecorator decorator;

        public SoccerGroupBetTypeController(GroupBetTypeWinLossService service, GroupBetTypeGridOptionsBuilder builder, GridOptionColumnDecoratorFull decorator)
        {
            this.service = service;
            this.builder = builder;
            this.decorator = decorator;
        }

        [Route("")]
        public IHttpActionResult Json(QueryModel queryModel)
        {
            var criteria = Mapper.Map<GroupBetTypeCriteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, string.Empty);
            gridOptions = decorator.Build(gridOptions, "Bet Type", 210);

            return Json(gridOptions);
        }

        [Route("excel")]
        public IHttpActionResult Excel(ExcelQueryModel queryModel)
        {
            var criteria = Mapper.Map<GroupBetTypeCriteria>(queryModel);
            var winlosses = service.Query(criteria);
            var gridOptions = builder.Build(winlosses, queryModel.Title);
            gridOptions = decorator.Build(gridOptions, "Bet Type", 210);

            return new FanexExcelResult(gridOptions, Constants.SheetName);
        }
    }
}