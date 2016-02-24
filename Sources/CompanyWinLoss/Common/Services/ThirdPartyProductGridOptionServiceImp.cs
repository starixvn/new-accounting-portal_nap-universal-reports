using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class ThirdPartyProductGridOptionServiceImp : ThirdPartyProductGridOptionService
    {
        public GridOptions FromWinLossModel(ThirdPartyProductWinLossModel winLoss)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                Columns = BuildHeader(),
                BodyRows = BuildBodyRows(winLoss.Products),
                FooterRows = BuildFooter(winLoss.GrandTotal),
                ShowFooter = true,
                ShowTree = true,
                ShowHighlightRow = false,
                ShowDistinctRow = false
            };
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        private List<HeaderColumns> BuildHeader()
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "3rd Party Product", Width = 150, Name = "ThirdPartyProduct", HeaderAlign = "center", CellAlignment = HAlignment.Center, ShowCollapseExpand = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "Margin", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GridDataRow> BuildBodyRows(List<SiteWinLossSummary> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var item in winLoss)
            {
                var row = BuildProductDataRow(item, HAlignment.Left);
                bodyRows.Add(row);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(SiteWinLossSummary item)
        {
            var footerRow = new List<GridDataRow>();
            footerRow.Add(BuildProductDataRow(item, HAlignment.Right));
            return footerRow;
        }

        private GridDataRow BuildProductDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var row = BuildDataRow(item.Total, alignment);
            var creditRow = BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = BuildDataRow(item.Deposit, HAlignment.Right);
            row.SubRows.AddRange(new List<GridDataRow> { creditRow, depositRow });

            return row;
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var customAttributes = $"{item.Id}";
            var columns = new List<Columns>
               {
                    new Columns { ColumnIndex = columnIndex++, Name = "ThirdPartyProduct", Value = string.IsNullOrEmpty(item.Name) ? string.Empty : item.Name, DisplayValue = item.Name, CustomAttributes = customAttributes, CellAlignment = alignment },
                    new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                    new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                    new Columns(columnIndex++, "Commission", item.Commission),
                    new Columns(columnIndex++, "RealIncome", item.RealIncome),
                    new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                    new Columns(columnIndex++, "Margin", item.RealTurnover == 0 ? "N/A" : (object)item.RealMargin)
               };

            return new GridDataRow { Columns = columns };
        }
    }
}
