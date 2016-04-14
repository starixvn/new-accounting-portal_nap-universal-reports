using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.ColumnBuilders;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class GridOptionServiceImp : GridOptionService
    {
        public GridOptions FromWinLossModel(ProductWinLoss winLoss, string title, bool hasNode)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                Columns = FullHeaderBuilder.BuildColumns("Main"),
                GroupHeaderRows = FullHeaderBuilder.BuildGroupHeaderRows("Main"),
                BodyRows = BuildBodyRows(winLoss),
                FooterRows = BuildFooter(winLoss.GrandTotal, hasNode),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,
                ShowTree = true
            };
        }

        private List<GridDataRow> BuildBodyRows(ProductWinLoss productWinLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var product in productWinLoss.SportsbookProducts.Products)
            {
                bodyRows.Add(BuildProduct(product));
            }

            foreach (var product in productWinLoss.SportsbookProducts.RM)
            {
                bodyRows.Add(BuildProductRM(product));
            }

            foreach (var product in productWinLoss.NoneSportsbookProducts.Products)
            {
                bodyRows.Add(BuildProduct(product));
            }

            bodyRows.Add(BuildNonSportsTotal(productWinLoss.NoneSportsbookProducts.Total));

            return bodyRows;
        }

        private GridDataRow BuildNonSportsTotal(SiteWinLossSummary productWinLoss)
        {
            var productName = productWinLoss.Total.Name;
            var productDataRow = BuildDataRow(productWinLoss.Total, HAlignment.Left, false);
            productDataRow.CssClass = "total-row";
            var subRow = BuildDataRow(productWinLoss.Credit, HAlignment.Right, false);
            subRow.CssClass = "total-row";
            productDataRow.SubRows.Add(subRow);
            subRow = BuildDataRow(productWinLoss.Deposit, HAlignment.Right, false);
            subRow.CssClass = "total-row";
            productDataRow.SubRows.Add(subRow);

            return productDataRow;
        }

        private GridDataRow BuildProductRM(WinLoss winLossRM)
        {
            var productName = winLossRM.Name;
            var productDataRow = BuildDataRow(winLossRM, HAlignment.Right, false);
            productDataRow.CssClass = "total-row";
            return productDataRow;
        }

        private GridDataRow BuildProduct(SiteWinLossSummary productWinLoss)
        {
            var productName = productWinLoss.Total.Name;
            var isSportsbook = productName.Contains("Sportsbook");
            var rowCssClass = isSportsbook ? "total-row" : string.Empty;
            var productDataRow = BuildDataRow(productWinLoss.Total, HAlignment.Left, false);
            productDataRow.CssClass = rowCssClass;
            productDataRow.CustomAttr = isSportsbook ? null : "product";
            var subRow = BuildDataRow(productWinLoss.Credit, HAlignment.Right, false);
            subRow.CssClass = rowCssClass;
            productDataRow.SubRows.Add(subRow);
            subRow = BuildDataRow(productWinLoss.Deposit, HAlignment.Right, false);
            subRow.CssClass = rowCssClass;
            productDataRow.SubRows.Add(subRow);

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
                new Columns(columnIndex++, "Variance", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "ExtraPT", item.ExtraPT),
                new Columns(columnIndex++, "AfterExtraPT", item.AfterExtraPT),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealMargin", GetFormattedMargin(item, isFooter)),
                new Columns(columnIndex++, "VirtualMargin", GetFormattedMargin(item, isFooter))
            };

            return new GridDataRow { Columns = columns };
        }

        private List<GridDataRow> BuildFooter(SiteWinLossSummary item, bool hasNode)
        {
            var list = new List<GridDataRow>
            {
                BuildDataRow(item.Total, HAlignment.Right, true),
                BuildDataRow(item.Credit, HAlignment.Right, true),
                BuildDataRow(item.Deposit, HAlignment.Right, true)
            };

            if (hasNode)
            {
                list.Add(BuildNoteRow());
            }

            return list;
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

        private GridDataRow BuildNoteRow()
        {
            var reportNote = "* Sportsbook Total: Sportsbook Live + Sportsbook Non-Live + Parlay + Outright" +
                             "<br/>* Grand Total: Sportsbook Total + Number Game + Live Casino + Casino + Virtual Sports + Keno + Racing +  Bingo + Bettrade + Colossus Bets";
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++)
                {
                    Name = "Main",
                    Value = reportNote,
                    MergeColNumber = 13,
                    CellAlignment = HAlignment.Left,
                    TDClass = "grand-total-note"
                }
            };

            return new GridDataRow { Columns = columns };
        }
    }
}