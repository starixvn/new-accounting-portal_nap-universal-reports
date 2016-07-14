using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
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
                TitleInfoText = title.ToUpper(),
                BodyRows = BuildBodyRows(winLoss),
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
            var sportsbookRMRows = BuildSportsbookRMRows(productWinLoss.RM);
            var nonSportsbookRows = BuildProductGroup(productWinLoss.NonSportsbook);

            var bodyRows = new List<GridDataRow>();
            bodyRows.AddRange(sportsbookRows);
            bodyRows.AddRange(sportsbookRMRows);
            bodyRows.Add(EmptyRow());
            bodyRows.AddRange(nonSportsbookRows);
            bodyRows.Add(EmptyRow());

            return bodyRows;
        }

        private List<GridDataRow> BuildProductGroup(ProductGroupWinLoss productGroupWinLoss)
        {
            var bodyRows = productGroupWinLoss
                .Products
                .Select(r => BuildSiteWinLossSummary(r, false))
                .ToList();
            var totalRow = BuildSiteWinLossSummary(productGroupWinLoss.Total, true);

            return new List<GridDataRow>(bodyRows) { totalRow };
        }

        private GridDataRow EmptyRow()
        {
            var colummns = new List<Columns>
            {
                new Columns
                {
                    ColumnIndex = 1,
                    Name = "Main",
                    Value = "",
                    MergeColNumber = 13
                }
            };

            return new GridDataRow
            {
                Columns = colummns,
                RowType = RowType.Normal,
                CssClass = string.Empty
            };
        }

        private GridDataRow BuildSiteWinLossSummary(SiteWinLossSummary productWinLoss, bool isTotal)
        {
            var rowCssClass = isTotal ? "total-row" : string.Empty;

            var productDataRow = gridDataRowBuilder.BuildDataRow(productWinLoss.Total, HAlignment.Left);
            productDataRow.CssClass = rowCssClass;
            productDataRow.RowType = isTotal ? RowType.SubTotal : RowType.ParentLevelOne;
            productDataRow.CustomAttr = isTotal ? null : "product";

            var creditRow = gridDataRowBuilder.BuildDataRow(productWinLoss.Credit, HAlignment.Right);
            creditRow.CssClass = rowCssClass;
            creditRow.RowType = isTotal ? RowType.SubTotal : RowType.Normal;
            productDataRow.SubRows.Add(creditRow);

            var depositRow = gridDataRowBuilder.BuildDataRow(productWinLoss.Deposit, HAlignment.Right);
            depositRow.CssClass = rowCssClass;
            depositRow.RowType = isTotal ? RowType.SubTotal : RowType.Normal;
            productDataRow.SubRows.Add(depositRow);

            return productDataRow;
        }

        private List<GridDataRow> BuildSportsbookRMRows(IEnumerable<WinLoss> winLosses)
        {
            var rows = winLosses
                .Select(w => gridDataRowBuilder.BuildDataRow(w, HAlignment.Right))
                .ToList();
            rows.ForEach(r =>
            {
                r.RowType = RowType.SubTotal;
                r.CssClass = "total-row";
            });

            return rows;
        }

        private List<GridDataRow> BuildFooter(SiteWinLossSummary item)
        {
            var rows = new List<GridDataRow>
            {
                gridDataRowBuilder.BuildDataRow(item.Total, HAlignment.Right),
                gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right),
                gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right)
            };

            rows.ForEach(r =>
            {
                r.Columns.First(c => c.Name == "VirtualMargin").Value = string.Empty;
                r.Columns.First(c => c.Name == "RealMargin").Value = string.Empty;
            });

            return rows;
        }
    }
}