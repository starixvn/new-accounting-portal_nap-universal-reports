using System.Collections.Generic;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public class GridOptionColumnDecoratorExtraPT : GridOptionColumnDecoratorBase, GridOptionColumnDecorator
    {
        public GridOptionColumnDecoratorExtraPT(GridOptionColumnRemoval columnRemoval) : base(columnRemoval)
        {
        }

        public GridOptions Build(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 180)
        {
            RemoveBodyAndFooterColumn(gridOptions, VirtualMarginIndex, VirtualTurnoverIndex, VirtualIncomeIndex, VarianceIndex);
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildExtraPTColumns(mainColumnText, mainColumnWidth);
            gridOptions.GroupHeaderRows = BuildExtraPtGroupHeaderRows(mainColumnText, mainColumnWidth);

            return gridOptions;
        }

        private List<HeaderColumns> BuildExtraPTColumns(string mainColumnText, int mainColumnWidth = 180)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Width = mainColumnWidth, Name = "Main", CellAlignment = HAlignment.Center, ShowCollapseExpand = true, IsBold = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 100, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 100, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 100, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Real", Width = 100, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Extra PT", Width = 100, Name = "ExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "After Extra PT", Width = 100, Name = "AfterExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "House Turnover", Width = 100, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 100, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GroupHeaderRows> BuildExtraPtGroupHeaderRows(string mainColumnText, int mainColumnWidth = 180)
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Name = "Main", MergeRowNumber = 2, Width = mainColumnWidth },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "House Income", Name = "RealIncome", MergeColNumber = 3, Width = 100 },
                new HeaderColumns { HeaderText = "House Turnover", Name = "RealTurnover", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "Margin", Name = "RealMargin", MergeRowNumber = 2, Width = 100 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }
    }
}