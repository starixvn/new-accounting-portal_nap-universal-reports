using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public class GridOptionColumnDecoratorFull : GridOptionColumnDecoratorBase, GridOptionColumnDecorator
    {
        public GridOptionColumnDecoratorFull(GridOptionColumnRemoval columnRemoval) : base(columnRemoval)
        {
        }

        public GridOptions Build(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 180)
        {
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildColumns(mainColumnText, mainColumnWidth);
            gridOptions.GroupHeaderRows = BuildGroupHeaderRows(mainColumnText, mainColumnWidth);

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
            "SP2100:CodeLineMustNotBeLongerThan",
            Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> BuildColumns(string mainColumnText, int mainColumnWidth = 180)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Width = mainColumnWidth, Name = "Main", CellAlignment = HAlignment.Center, ShowCollapseExpand = true, IsBold = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 100, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 100, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 100, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Variance", Width = 100, Name = "VarianceIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 100, Name = "VirtualIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 100, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Extra PT", Width = 100, Name = "ExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "After Extra PT", Width = 100, Name = "AfterExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 100, Name = "VirtualTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Real", Width = 100, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Virtual", Width = 100, Name = "VirtualMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 100, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        protected List<GroupHeaderRows> BuildGroupHeaderRows(string mainColumnText, int mainColumnWidth = 180)
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Name = "Main", MergeRowNumber = 2, Width = mainColumnWidth },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission", MergeRowNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "House Income", Name = "VirtualIncome", MergeColNumber = 5, Width = 100 },
                new HeaderColumns { HeaderText = "House Turnover", Name = "VirtualTurnover", MergeColNumber = 2, Width = 100 },
                new HeaderColumns { HeaderText = "Margin", Name = "VirtualMargin", MergeColNumber = 2, Width = 100 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }
    }
}