using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.CompanyWinLoss.Common.ColumnDecorators
{
    public class MatchGridOptionColumnDecoratorBasic : GridOptionColumnDecoratorBase, MatchGridOptionColumnDecorator
    {
        public MatchGridOptionColumnDecoratorBasic(GridOptionColumnRemoval columnRemoval) : base(columnRemoval)
        {
        }

        public GridOptions Build(GridOptions gridOptions)
        {
            RemoveBodyAndFooterColumn(gridOptions, MatchDetailVirtualMarginIndex, MatchDetailVirtualTurnoverIndex, MatchDetailVirtualIncomeIndex, MatchDetailVarianceIndex);
            gridOptions.CustomizeHeader = false;
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
                new HeaderColumns { HeaderText = "Code", Width = 120, Name = "MatchCode", CellAlignment = HAlignment.Center, Bold = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 100, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 100, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 100, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 100, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 100, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 100, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        protected List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Name = "MatchCode", Width = 120 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 100 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss",  Width = 100 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission",  Width = 100 },
                new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome", Width = 100 },
                new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover",  Width = 100 },
                new HeaderColumns { HeaderText = "Margin", Name = "RealMargin",  Width = 100 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }
    }
}
