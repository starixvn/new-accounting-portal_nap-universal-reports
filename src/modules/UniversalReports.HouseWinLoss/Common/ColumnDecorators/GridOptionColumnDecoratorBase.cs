using Fanex.Excel.Models;
using System.Collections.Generic;

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
    }
}