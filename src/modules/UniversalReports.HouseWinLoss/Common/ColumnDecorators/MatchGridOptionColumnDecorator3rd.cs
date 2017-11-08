using System.Collections.Generic;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public class MatchGridOptionColumnDecorator3rd : GridOptionColumnDecoratorBase, MatchGridOptionColumnDecorator
    {
        public MatchGridOptionColumnDecorator3rd(GridOptionColumnRemoval columnRemoval) : base(columnRemoval)
        {
        }

        public GridOptions Build(GridOptions gridOptions)
        {
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildThirdPartyColumns();
            gridOptions.GroupHeaderRows = BuildThirdPartyGroupHeaderRows();

            return gridOptions;
        }

        private List<HeaderColumns> BuildThirdPartyColumns()
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Width = 140, Name = "MatchCode", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 200, Name = "Home", CellAlignment = HAlignment.Right },
                new HeaderColumns { HeaderText = string.Empty, Width = 20, Name = "VS", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 200, Name = "Away", CellAlignment = HAlignment.Left },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "House Income", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "House Turnover", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GroupHeaderRows> BuildThirdPartyGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Name = "MatchCode", Width = 140, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Event", Name = "Home", Width = 420, MergeColNumber = 3, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "House Income", Name = "RealIncome", Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "House Turnover", Name = "RealTurnover",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Margin", Name = "RealMargin",  Width = 120, MergeRowNumber = 2 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }
    }
}
