using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UniversalReports.CompanyWinLoss.Common.ColumnDecorators
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
                MatchDetailVSIndex);
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildColumns();
            gridOptions.GroupHeaderRows = BuildGroupHeaderRows();

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> BuildColumns()
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Width = 130, Name = "MatchCode", CellAlignment = HAlignment.Center, Bold = true },
                new HeaderColumns { HeaderText = "Home", Width = 150, Name = "Home", CellAlignment = HAlignment.Right },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 100, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 100, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 100, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Variance", Width = 100, Name = "VarianceIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 100, Name = "VirtualIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 100, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 100, Name = "VirtualTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Real", Width = 100, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Virtual", Width = 50, Name = "VirtualMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 50, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        protected List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Name = "MatchCode", Width = 130, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Event", Name = "Home", Width = 200, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss",  Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission",  Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome", Width = 100, MergeColNumber = 3 },
                new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover",  Width = 100, MergeColNumber = 2 },
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
