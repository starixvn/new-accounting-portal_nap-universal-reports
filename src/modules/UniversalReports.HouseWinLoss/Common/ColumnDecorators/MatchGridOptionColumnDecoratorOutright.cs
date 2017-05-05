using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public class MatchGridOptionColumnDecoratorOutright : GridOptionColumnDecoratorBase, MatchGridOptionColumnDecorator
    {
        public MatchGridOptionColumnDecoratorOutright(GridOptionColumnRemoval columnRemoval) : base(columnRemoval)
        {
        }

        public GridOptions Build(GridOptions gridOptions)
        {
            DecorateMatchRow(gridOptions);
            RemoveBodyAndFooterColumn(
                gridOptions,
                MatchDetailAwayIndex,
                MatchDetailVsIndex);
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildOutrightColumns();
            gridOptions.GroupHeaderRows = BuildOutrightGroupHeaderRows();

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed. Suppression is OK here.")]
        private List<HeaderColumns> BuildOutrightColumns()
        {
            var headerColumns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Width = 130, Name = "MatchCode", CellAlignment = HAlignment.Center, Bold = true },
                new HeaderColumns { HeaderText = "Home", Width = 150, Name = "Home", CellAlignment = HAlignment.Right }
            };
            var baseHeaderColumns = CreateCoreHeaderColumns();
            headerColumns.AddRange(baseHeaderColumns);

            return headerColumns;
        }

        private List<GroupHeaderRows> BuildOutrightGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Name = "MatchCode", Width = 130, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Event", Name = "Home", Width = 150, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss",  Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission",  Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "House Income", Name = "RealIncome", Width = 300, MergeColNumber = 3 },
                new HeaderColumns { HeaderText = "House Turnover", Name = "RealTurnover",  Width = 200, MergeColNumber = 2 },
                new HeaderColumns { HeaderText = "Margin", Name = "VirtualMargin",  Width = 100, MergeColNumber = 2 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }

        private void DecorateMatchRow(GridOptions gridOptions)
        {
            var matchRows = gridOptions
                .BodyRows
                .Where(r => r.Columns.Count > 1 && r.Columns[1].Name == "Home")
                .ToList();
            matchRows.ForEach(r =>
            {
                r.Columns[1].CellAlignment = HAlignment.Center;
                r.Columns[0].CustomAttributes = null;
            });
        }
    }
}