using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Extensions;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Configuration;

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
                .Select(r => BuildSiteWinLossSummary(r))
                .ToList();
            var totalRow = BuildSiteWinLossSummaryForTotalRow(productGroupWinLoss.Total);

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
                    Value = string.Empty,
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

        private GridDataRow BuildSiteWinLossSummary(SiteWinLossSummary winloss)
        {
            var gridDataRow = BuildRawSiteWinLossSummary(winloss);
            DecorateExtraPT(gridDataRow, winloss);

            return gridDataRow;
        }

        private GridDataRow BuildRawSiteWinLossSummary(SiteWinLossSummary winloss)
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

        private void DecorateExtraPT(GridDataRow gridDataRow, SiteWinLossSummary item)
        {
            var itemHasExtraPT = ItemHasExtraPT(item.Total);
            DecorateExtraPT(gridDataRow, item.Total, itemHasExtraPT);
            DecorateExtraPT(gridDataRow.SubRows[0], item.Credit, itemHasExtraPT);
            DecorateExtraPT(gridDataRow.SubRows[1], item.Deposit, itemHasExtraPT);
        }

        private void DecorateExtraPT(GridDataRow gridDataRow, WinLoss item, bool itemHasExtraPT)
        {
            gridDataRow.Columns.First(c => c.Name == "ExtraPT").Value = item.ExcelExtraPT(itemHasExtraPT);
        }

        private bool ItemHasExtraPT(WinLoss item)
        {
            return Constants.ProductsExtraPT.Contains(item.Name);
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

            rows.ForEach(r => DecorateExtraPTForRMRows(r));

            return rows;
        }

        private void DecorateExtraPTForRMRows(GridDataRow gridDataRow)
        {
            gridDataRow.Columns.First(c => c.Name == "ExtraPT").Value = "N/A";
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