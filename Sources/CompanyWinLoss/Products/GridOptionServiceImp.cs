using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
                Columns = BuildHeader(),
                GroupHeaderRows = BuildGroupHeaderRows(),
               // BodyRows = BuildBodyRows(winLoss.SportsbookDetail, winLoss.Products),
                FooterRows = BuildFooter(winLoss.GrandTotal, hasNode),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,
                ShowTree = true
            };
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        private List<HeaderColumns> BuildHeader()
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Product", Width = 150, Name = "Product", CellAlignment = HAlignment.Center, ShowCollapseExpand = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Variance", Width = 120, Name = "Variance", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Extra PT", Width = 120, Name = "ExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "After Extra PT", Width = 120, Name = "AfterExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
            };
        }

        private List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Product", Name = "Product", MergeRowNumber = 2, Width = 150 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", MergeRowNumber = 2, Width = 120 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss", MergeRowNumber = 2, Width = 120 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission", MergeRowNumber = 2, Width = 120 },
                new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome", MergeColNumber = 5, Width = 120 },
                new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover", MergeColNumber = 2, Width = 120 },
                new HeaderColumns { HeaderText = "Margin", Name = "RealMargin", MergeColNumber = 2, Width = 120 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }

        private List<GridDataRow> BuildBodyRows(IList<WinLoss> sportsbookDetail, IList<SiteWinLossSummary> products)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var winLoss in sportsbookDetail)
            {
                bodyRows.Add(BuildDataRow(winLoss, HAlignment.Left, false));
            }

            foreach (var product in products)
            {
                bodyRows.Add(BuildProduct(product));
            }

            return bodyRows;
        }

        private GridDataRow BuildProduct(SiteWinLossSummary productWinLoss)
        {
            var productName = productWinLoss.Total.Name;
            var isSportsbook = productName == "Sportsbook Total";
            var rowCssClass = isSportsbook ? "highlight-product" : string.Empty;
            var productDataRow = BuildDataRow(productWinLoss.Total, HAlignment.Left, false);
            productDataRow.CssClass = rowCssClass;
            productDataRow.CustomAttr = "product";
            productDataRow.SubRows.Add(BuildDataRow(productWinLoss.Credit, HAlignment.Right, false));
            productDataRow.SubRows.Add(BuildDataRow(productWinLoss.Deposit, HAlignment.Right, false));

            return productDataRow;
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment, bool isFooter)
        {
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "Product", item.Name, alignment),
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
                    Name = "Product",
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