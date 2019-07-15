using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Soccer.BetType;

namespace UniversalReports.CN88WinLoss.Soccer.BetTypeFull
{
    public class GridOptionFactoryBetType : GridOptionFactory
    {
        private readonly BasicWinLossService basicWinLossService;

        private readonly BasicGridOptionsBuilder basicGridOptionsBuilder;

        private readonly GridOptionColumnDecorator decorator;

        public GridOptionFactoryBetType(
            BasicWinLossService basicWinLossService,
            BasicGridOptionsBuilder basicGridOptionsBuilder,
            GridOptionColumnDecorator decorator)
        {
            this.basicWinLossService = basicWinLossService;
            this.basicGridOptionsBuilder = basicGridOptionsBuilder;
            this.decorator = decorator;
        }

        public GridOptions CreateGridOption(ExcelQueryModel queryModel, string title, int isLive)
        {
            var criteria = Mapper.Map<BetTypeCriteria>(queryModel);
            criteria.IsLive = isLive;

            var winlosses = basicWinLossService.Query(criteria);

            var gridOptions = basicGridOptionsBuilder.Build(winlosses, title);

            return decorator.Build(gridOptions, "Bet Type");
        }
    }
}
