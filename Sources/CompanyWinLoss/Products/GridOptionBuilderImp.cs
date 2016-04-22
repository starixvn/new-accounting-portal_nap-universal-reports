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
            var bodyRows = productWinLoss.SportsbookProducts.Products.Select(BuildProduct).ToList();
            bodyRows.AddRange(productWinLoss.SportsbookProducts.RM.Select(BuildProductRM));
            bodyRows.AddRange(productWinLoss.NoneSportsbookProducts.Products.Select(BuildProduct));
            bodyRows.Add(BuildNonSportsTotal(productWinLoss.NoneSportsbookProducts.Total));

            return bodyRows;
        }

        private GridDataRow BuildProduct(SiteWinLossSummary productWinLoss)
        {
            var productName = productWinLoss.Total.Name;
            var isSportsbook = productName.Contains("Sportsbook");
            var rowCssClass = isSportsbook ? "total-row" : string.Empty;
            var isTotal = productName.Contains("Total");

            var productDataRow = BuildDataRow(productWinLoss.Total, HAlignment.Left, false);
            productDataRow.CssClass = rowCssClass;
            productDataRow.RowType = isTotal ? RowType.SubTotal : RowType.ParentLevelOne;
            productDataRow.CustomAttr = isSportsbook ? null : "product";

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

        private GridDataRow BuildNonSportsTotal(SiteWinLossSummary productWinLoss)
        {
            var productDataRow = BuildDataRow(productWinLoss.Total, HAlignment.Left, false);
            productDataRow.CssClass = "total-row";
            productDataRow.RowType = RowType.SubTotal;

            var creditRow = BuildDataRow(productWinLoss.Credit, HAlignment.Right, false);
            creditRow.CssClass = "total-row";
            creditRow.RowType = RowType.SubTotal;
            productDataRow.SubRows.Add(creditRow);

            var depositRow = BuildDataRow(productWinLoss.Deposit, HAlignment.Right, false);
            depositRow.CssClass = "total-row";
            depositRow.RowType = RowType.SubTotal;
            productDataRow.SubRows.Add(depositRow);

            return productDataRow;
        }

        private GridDataRow BuildProductRM(WinLoss winLossRM)
        {
            var productDataRow = BuildDataRow(winLossRM, HAlignment.Right, false);
            productDataRow.CssClass = "total-row";
            productDataRow.RowType = RowType.SubTotal;
            return productDataRow;
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