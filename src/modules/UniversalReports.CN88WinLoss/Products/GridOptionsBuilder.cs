using System.Collections.Generic;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Products
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(ProductWinLoss winLoss, string title);
    }

    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private readonly BasicGridDataRowBuilder gridDataRowBuilder;

        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            this.gridDataRowBuilder = gridDataRowBuilder;
        }

        public GridOptions Build(ProductWinLoss winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title.ToUpperInvariant(),
                BodyRows = winLoss.IsEmpty ? new List<GridDataRow>() : BuildBodyRows(winLoss),
                FooterRows = BuildFooter(winLoss.GrandTotal),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,
                ShowTree = true
            };
        }

        private List<GridDataRow> BuildBodyRows(ProductWinLoss productWinLoss)
        {
            var sportsbookRows = BuildProductGroup(productWinLoss.Sportsbook);
            var nonSportsbookRows = BuildProductGroup(productWinLoss.NonSportsbook);

            var bodyRows = new List<GridDataRow>();
            bodyRows.AddRange(sportsbookRows);
            if (sportsbookRows.Any())
            {
                bodyRows.Add(EmptyRow());
            }

            bodyRows.AddRange(nonSportsbookRows);

            if (nonSportsbookRows.Any())
            {
                bodyRows.Add(EmptyRow());
            }

            return bodyRows;
        }

        private IEnumerable<GridDataRow> BuildProductGroup(ProductGroupWinLoss productGroupWinLoss)
        {
            var bodyRows = productGroupWinLoss
                .Products
                .Select(BuildWinLoss)
                .ToList();

            var result = new List<GridDataRow>(bodyRows);
            if (bodyRows.Any())
            {
                var totalRow = BuildWinLossForTotalRow(productGroupWinLoss.Total);
                result.Add(totalRow);
            }

            return result;
        }

        private GridDataRow EmptyRow()
        {
            var colummns = new List<Columns>
            {
                new Columns { ColumnIndex = 1, Name = "Main", Value = string.Empty, MergeColNumber = 13 }
            };

            return new GridDataRow { Columns = colummns, RowType = RowType.Normal, CssClass = string.Empty };
        }

        private GridDataRow BuildWinLoss(WinLoss winloss)
        {
            const string RowCssClass = "parent-row";
            var productDataRow = gridDataRowBuilder.BuildDataRow(winloss, HAlignment.Left);
            productDataRow.RowType = RowType.ParentLevelOne;
            productDataRow.CustomAttr = "product";
            productDataRow.CssClass = RowCssClass;

            return productDataRow;
        }

        private GridDataRow BuildWinLossForTotalRow(WinLoss productWinLoss)
        {
            const string RowCssClass = "total-row-main";
            var productDataRow = gridDataRowBuilder.BuildDataRow(productWinLoss, HAlignment.Right);
            productDataRow.CssClass = RowCssClass;
            productDataRow.RowType = RowType.SubTotal;
            productDataRow.CustomAttr = null;

            return productDataRow;
        }


        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            var row = gridDataRowBuilder.BuildDataRow(item, HAlignment.Right);
            FormatTotalRow(row);

            return new List<GridDataRow> { row };
        }

        private static void FormatTotalRow(GridDataRow row)
        {
            row.CssClass = "grand-total";
            row.Columns.First(c => c.Name == "VirtualMargin").Value = string.Empty;
            row.Columns.First(c => c.Name == "RealMargin").Value = string.Empty;
        }
    }
}