using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Products
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
            var sportsbookRMRows = BuildSportsbookRmRows(productWinLoss.RM);
            var nonSportsbookRows = BuildProductGroup(productWinLoss.NonSportsbook);

            var bodyRows = new List<GridDataRow>();
            bodyRows.AddRange(sportsbookRows);
            bodyRows.AddRange(sportsbookRMRows);
            bodyRows.Add(EmptyRow());
            bodyRows.AddRange(nonSportsbookRows);
            bodyRows.Add(EmptyRow());

            return bodyRows;
        }

        private IEnumerable<GridDataRow> BuildProductGroup(ProductGroupWinLoss productGroupWinLoss)
        {
            var bodyRows = productGroupWinLoss
                .Products
                .Select(BuildSiteWinLossSummary)
                .ToList();
            var totalRow = BuildSiteWinLossSummaryForTotalRow(productGroupWinLoss.Total);

            return new List<GridDataRow>(bodyRows) { totalRow };
        }

        private GridDataRow EmptyRow()
        {
            var colummns = new List<Columns>
            {
                new Columns { ColumnIndex = 1, Name = "Main", Value = string.Empty, MergeColNumber = 13 }
            };

            return new GridDataRow { Columns = colummns, RowType = RowType.Normal, CssClass = string.Empty };
        }

        private GridDataRow BuildSiteWinLossSummary(SiteWinLossSummary winloss)
        {
            var productDataRow = gridDataRowBuilder.BuildDataRow(winloss.Total, HAlignment.Left);
            productDataRow.RowType = RowType.ParentLevelOne;
            productDataRow.CustomAttr = "product";

            var creditRow = gridDataRowBuilder.BuildDataRow(winloss.Credit, HAlignment.Right);
            creditRow.RowType = RowType.Normal;
            productDataRow.SubRows.Add(creditRow);

            var depositRow = gridDataRowBuilder.BuildDataRow(winloss.Deposit, HAlignment.Right);
            depositRow.RowType = RowType.Normal;
            productDataRow.SubRows.Add(depositRow);

            return productDataRow;
        }

        private GridDataRow BuildSiteWinLossSummaryForTotalRow(SiteWinLossSummary productWinLoss)
        {
            const string RowCssClass = "total-row-main";
            var productDataRow = gridDataRowBuilder.BuildDataRow(productWinLoss.Total, HAlignment.Right);
            productDataRow.CssClass = RowCssClass;
            productDataRow.RowType = RowType.SubTotal;
            productDataRow.CustomAttr = null;

            var creditRow = gridDataRowBuilder.BuildDataRow(productWinLoss.Credit, HAlignment.Right);
            creditRow.CssClass = RowCssClass;
            creditRow.RowType = RowType.SubTotal;
            productDataRow.SubRows.Add(creditRow);

            var depositRow = gridDataRowBuilder.BuildDataRow(productWinLoss.Deposit, HAlignment.Right);
            depositRow.CssClass = RowCssClass;
            depositRow.RowType = RowType.SubTotal;
            productDataRow.SubRows.Add(depositRow);

            return productDataRow;
        }

        private IEnumerable<GridDataRow> BuildSportsbookRmRows(IEnumerable<WinLoss> winLosses)
        {
            var rows = winLosses
                .Select(w => gridDataRowBuilder.BuildDataRow(w, HAlignment.Right))
                .ToList();
            rows.ForEach(r =>
            {
                r.RowType = RowType.SubTotal;
                r.CssClass = "total-row-main";
            });

            return rows;
        }

        private List<GridDataRow> BuildFooter(SiteWinLossSummary item)
        {
            var row = gridDataRowBuilder.BuildDataRow(item.Total, HAlignment.Right);
            var creditRow = gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);

            FormatTotalRow(row);
            FormatTotalRow(creditRow);
            FormatTotalRow(depositRow);

            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

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