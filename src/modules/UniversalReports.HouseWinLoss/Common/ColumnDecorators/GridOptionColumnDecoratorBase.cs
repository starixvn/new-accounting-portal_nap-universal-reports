using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.HouseWinLoss.Common.ColumnDecorators
{
    public abstract class GridOptionColumnDecoratorBase
    {
        protected const int VarianceIndex = 4;

        protected const int VirtualIncomeIndex = 5;

        protected const int RealIncomeIndex = 6;

        protected const int ExtraPTIndex = 7;

        protected const int AfterExtraPTIndex = 8;

        protected const int VirtualTurnoverIndex = 9;

        protected const int RealTurnover = 10;

        protected const int VirtualMarginIndex = 11;

        protected const int RealMarginIndex = 12;

        protected const int MatchDetailVsIndex = 2;

        protected const int MatchDetailAwayIndex = 3;

        protected const int MatchDetailVarianceIndex = 7;

        protected const int MatchDetailVirtualIncomeIndex = 8;

        protected const int MatchDetailVirtualTurnoverIndex = 10;

        protected const int MatchDetailVirtualMarginIndex = 12;

        private readonly GridOptionColumnRemoval columnRemoval;

        protected GridOptionColumnDecoratorBase(GridOptionColumnRemoval columnRemoval)
        {
            this.columnRemoval = columnRemoval;
        }

        protected void RemoveBodyAndFooterColumn(GridOptions gridOptions, params int[] indice)
        {
            foreach (var index in indice)
            {
                if (gridOptions.BodyRows != null)
                {
                    RemoveColumn(gridOptions.BodyRows, index);
                }

                if (gridOptions.FooterRows != null)
                {
                    RemoveColumn(gridOptions.FooterRows, index);
                }
            }
        }

        private void RemoveColumn(IEnumerable<GridDataRow> rows, int index)
        {
            foreach (var row in rows)
            {
                RemoveColumn(row, index);
            }
        }

        private void RemoveColumn(GridDataRow row, int index)
        {
            columnRemoval.RemoveColumn(row.Columns, index);
            if (row.SubRows == null)
            {
                return;
            }

            foreach (var subRow in row.SubRows)
            {
                RemoveColumn(subRow, index);
            }
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> CreateCoreHeaderColumns()
        {
            return new List<HeaderColumns>
            {
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
    }
}