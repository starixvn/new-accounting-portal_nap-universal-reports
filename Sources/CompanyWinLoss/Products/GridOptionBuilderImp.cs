using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class GridOptionBuilderImp : GridOptionBuilder
    {
        public GridOptions Build(ProductWinLoss winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
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
            bodyRows.AddRange(nonSportsbookRows);

            return bodyRows;
        }

        private List<GridDataRow> BuildProductGroup(ProductGroupWinLoss productGroupWinLoss)
        {
            var bodyRows = productGroupWinLoss
                .Products
                .Select(r => BuildSiteWinLossSummary(r, false))
                .ToList();
            var totalRow = BuildSiteWinLossSummary(productGroupWinLoss.Total, true);

            var rows = new List<GridDataRow>(bodyRows);
            rows.Add(totalRow);

            return rows;
        }

        private GridDataRow BuildSiteWinLossSummary(SiteWinLossSummary productWinLoss, bool isTotal)
        {
            var productName = productWinLoss.Total.Name;
            var rowCssClass = isTotal ? "total-row" : string.Empty;

            var productDataRow = BuildDataRow(productWinLoss.Total, HAlignment.Left, false);
            productDataRow.CssClass = rowCssClass;
            productDataRow.RowType = isTotal ? RowType.SubTotal : RowType.ParentLevelOne;
            productDataRow.CustomAttr = isTotal ? null : "product";

            var creditRow = BuildDataRow(productWinLoss.Credit, HAlignment.Right, false);
            creditRow.CssClass = rowCssClass;
            creditRow.RowType = isTotal ? RowType.SubTotal : RowType.Normal;
            productDataRow.SubRows.Add(creditRow);

            var depositRow = BuildDataRow(productWinLoss.Deposit, HAlignment.Right, false);
            depositRow.CssClass = rowCssClass;
            depositRow.RowType = isTotal ? RowType.SubTotal : RowType.Normal;
            productDataRow.SubRows.Add(depositRow);

            return productDataRow;
        }

        private List<GridDataRow> BuildSportsbookRMRows(List<WinLoss> winLosses)
        {
            var rows = winLosses
                .Select(w => BuildDataRow(w, HAlignment.Right, false))
                .ToList();
            rows.ForEach(r =>
            {
                r.RowType = RowType.SubTotal;
                r.CssClass = "total-row";
            });

            return rows;
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment, bool isFooter)
        {
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "Main", item.Name, alignment),
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "ExtraPT", item.ExtraPT),
                new Columns(columnIndex++, "AfterExtraPT", item.AfterExtraPT),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealMargin", GetFormattedMargin(item, isFooter)),
                new Columns(columnIndex, "VirtualMargin", GetFormattedMargin(item, isFooter))
            };

            return new GridDataRow { Columns = columns };
        }

        private List<GridDataRow> BuildFooter(SiteWinLossSummary item)
        {
            return new List<GridDataRow>
            {
                BuildDataRow(item.Total, HAlignment.Right, true),
                BuildDataRow(item.Credit, HAlignment.Right, true),
                BuildDataRow(item.Deposit, HAlignment.Right, true)
            };
        }

        private object GetFormattedMargin(WinLoss item, bool isFooter)
        {
            if (isFooter)
            {
                return string.Empty;
            }
            else
            {
                return item.RealMargin == 0 ? "N/A" : (object)item.RealMargin;
            }
        }
    }
}