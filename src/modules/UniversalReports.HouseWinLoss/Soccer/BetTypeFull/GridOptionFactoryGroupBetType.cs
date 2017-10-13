using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Soccer.GroupBetType;

namespace UniversalReports.HouseWinLoss.Soccer.BetTypeFull
{
    public class GridOptionFactoryGroupBetType : GridOptionFactory
    {
        private readonly GroupBetTypeWinLossService groupBetTypeWinLossService;

        private readonly GroupBetTypeGridOptionsBuilder groupBetTypeGridOptionsBuilder;

        private readonly GridOptionColumnDecorator decorator;

        public GridOptionFactoryGroupBetType(
            GroupBetTypeWinLossService groupBetTypeWinLossService,
            GroupBetTypeGridOptionsBuilder groupBetTypeGridOptionsBuilder,
            GridOptionColumnDecorator decorator)
        {
            this.groupBetTypeWinLossService = groupBetTypeWinLossService;
            this.groupBetTypeGridOptionsBuilder = groupBetTypeGridOptionsBuilder;
            this.decorator = decorator;
        }

        public GridOptions CreateGridOption(ExcelQueryModel queryModel, string title, int isLive)
        {
            var criteria = Mapper.Map<GroupBetTypeCriteria>(queryModel);
            criteria.IsLive = isLive;

            var winlosses = groupBetTypeWinLossService.Query(criteria);

            var gridOptions = groupBetTypeGridOptionsBuilder.Build(winlosses, title);

            return decorator.Build(gridOptions, "Bet Type");
        }
    }
}
