using Fanex.Excel.Models;
using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.ColumnBuilders
{
    public class GridOptionBuilderImp : GridOptionBuilder
    {
        private const int VarianceIndex = 4;

        private const int VirtualIncomeIndex = 5;

        private const int RealIncomeIndex = 6;

        private const int ExtraPTIndex = 7;

        private const int AfterExtraPTIndex = 8;

        private const int VirtualTurnoverIndex = 9;

        private const int RealTurnover = 10;

        private const int VirtualMarginIndex = 11;

        private const int RealMarginIndex = 12;

        private const int MatchDetailVirtualIncomeIndex = 8;

        private const int MatchDetailVarianceIndex = 9;

        private const int MatchDetailVirtualTurnoverIndex = 11;

        private const int MatchDetailVirtualMarginIndex = 13;

        private readonly ColumnBuilder columnBuilder;

        public GridOptionBuilderImp(ColumnBuilder columnBuilder)
        {
            this.columnBuilder = columnBuilder;
        }

        public GridOptions BuildFullGridOptions(GridOptions gridOptions, string mainColumnText)
        {
            gridOptions.Columns = FullHeaderBuilder.BuildColumns(mainColumnText);
            gridOptions.GroupHeaderRows = FullHeaderBuilder.BuildGroupHeaderRows(mainColumnText);

            return gridOptions;
        }

        public GridOptions BuildVirtualGridOptions(GridOptions gridOptions, string mainColumnText)
        {
            RemoveBodyAndFooterColumn(gridOptions, AfterExtraPTIndex, ExtraPTIndex);
            gridOptions.Columns = VirtualHeaderBuilder.BuildColumns(mainColumnText);
            gridOptions.GroupHeaderRows = VirtualHeaderBuilder.BuildGroupHeaderRows(mainColumnText);

            return gridOptions;
        }

        public GridOptions BuildExtraPTGridOptions(GridOptions gridOptions, string mainColumnText)
        {
            RemoveBodyAndFooterColumn(gridOptions, VirtualMarginIndex, VirtualTurnoverIndex, VirtualIncomeIndex, VarianceIndex);
            gridOptions.Columns = ExtraPTHeaderBuilder.BuildColumns(mainColumnText);
            gridOptions.GroupHeaderRows = ExtraPTHeaderBuilder.BuildGroupHeaderRows(mainColumnText);

            return gridOptions;
        }

        public GridOptions BuildBasicGridOptions(GridOptions gridOptions, string mainColumnText)
        {
            RemoveBodyAndFooterColumn(gridOptions, VirtualMarginIndex, VirtualTurnoverIndex, AfterExtraPTIndex, ExtraPTIndex, VirtualIncomeIndex, VarianceIndex);
            gridOptions.Columns = BasicHeaderBuilder.BuildColumns(mainColumnText);
            gridOptions.GroupHeaderRows = BasicHeaderBuilder.BuildGroupHeaderRows(mainColumnText);

            return gridOptions;
        }

        public GridOptions BuildBasicMatchDetailOptions(GridOptions gridOptions)
        {
            RemoveBodyAndFooterColumn(gridOptions, MatchDetailVirtualMarginIndex, MatchDetailVirtualTurnoverIndex, MatchDetailVirtualIncomeIndex, MatchDetailVarianceIndex);
            gridOptions.Columns = MatchDetailBasicHeaderBuilder.BuildColumns();
            gridOptions.GroupHeaderRows = MatchDetailBasicHeaderBuilder.BuildGroupHeaderRows();

            return gridOptions;
        }

        public GridOptions BuildFullMatchDetailOptions(GridOptions gridOptions)
        {
            gridOptions.Columns = MatchDetailFullHeaderBuilder.BuildColumns();
            gridOptions.GroupHeaderRows = MatchDetailFullHeaderBuilder.BuildGroupHeaderRows();

            return gridOptions;
        }

        private void RemoveBodyAndFooterColumn(GridOptions gridOptions, params int[] indice)
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

        private void RemoveColumn(List<GridDataRow> rows, params int[] indice)
        {
            foreach (var index in indice)
            {
                RemoveColumn(rows, index);
            }
        }

        private void RemoveColumn(List<GridDataRow> rows, int index)
        {
            foreach (var row in rows)
            {
                RemoveColumn(row, index);
            }
        }

        private void RemoveColumn(GridDataRow row, int index)
        {
            columnBuilder.RemoveColumn(row.Columns, index);
            if (row.SubRows != null)
            {
                foreach (var subRow in row.SubRows)
                {
                    RemoveColumn(subRow, index);
                }
            }
        }
    }
}
