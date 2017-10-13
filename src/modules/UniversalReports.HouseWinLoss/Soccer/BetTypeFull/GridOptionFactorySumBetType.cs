using AutoMapper;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.ColumnDecorators;
using UniversalReports.HouseWinLoss.Soccer.SumBetType;

namespace UniversalReports.HouseWinLoss.Soccer.BetTypeFull
{
    public class GridOptionFactorySumBetType : GridOptionFactory
    {
        private readonly SumBetTypeWinLossService sumBetTypeWinLossService;

        private readonly SumBetTypeGridOptionsBuilder sumBetTypeGridOptionsBuilder;

        private readonly GridOptionColumnDecorator decorator;

        public GridOptionFactorySumBetType(
            SumBetTypeWinLossService sumBetTypeWinLossService,
            SumBetTypeGridOptionsBuilder sumBetTypeGridOptionsBuilder,
            GridOptionColumnDecorator decorator)
        {
            this.sumBetTypeWinLossService = sumBetTypeWinLossService;
            this.sumBetTypeGridOptionsBuilder = sumBetTypeGridOptionsBuilder;
            this.decorator = decorator;
        }

        public GridOptions CreateGridOption(ExcelQueryModel queryModel, string title, int isLive)
        {
            var criteria = Mapper.Map<SumBetTypeCriteria>(queryModel);
            criteria.IsLive = isLive;

            var winlosses = sumBetTypeWinLossService.Query(criteria);
            var gridOptions = sumBetTypeGridOptionsBuilder.Build(winlosses, title);

            return decorator.Build(gridOptions, "Bet Type");
        }
    }
}
