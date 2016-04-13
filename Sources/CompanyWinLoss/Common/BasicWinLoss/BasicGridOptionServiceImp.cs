using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public class BasicGridOptionServiceImp : BasicGridOptionService
    {
        public GridOptions FromWinLossModel(BasicWinLossModel winLoss, string title, string mainColumnText)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                Columns = BuildHeader(mainColumnText),
                BodyRows = BuildBodyRows(winLoss.SiteWinLossSummaries),
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
        private List<HeaderColumns> BuildHeader(string mainColumnText)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Width = 150, Name = "MainColumn", CellAlignment = HAlignment.Center, ShowCollapseExpand = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "Margin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GridDataRow> BuildBodyRows(List<SiteWinLossSummary> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var item in winLoss)
            {
                var row = BuildBetTypeDataRow(item, HAlignment.Left);
                bodyRows.Add(row);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(SiteWinLossSummary item)
        {
            var row = BuildDataRow(item.Total, HAlignment.Right);
            var creditRow = BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = BuildDataRow(item.Deposit, HAlignment.Right);

            return new List<GridDataRow> { row, creditRow, depositRow };
        }

        private GridDataRow BuildBetTypeDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var row = BuildDataRow(item.Total, alignment);
            var creditRow = BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = BuildDataRow(item.Deposit, HAlignment.Right);
            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

            return row;
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
         "SP2100:CodeLineMustNotBeLongerThan",
         Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var betTypeId = $"{item.Id}";
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "MainColumn", Value = string.IsNullOrEmpty(item.Name) ? string.Empty : item.Name, DisplayValue = item.Name, CustomAttributes = betTypeId, CellAlignment = alignment },
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns { ColumnIndex = columnIndex++, Name = "Margin", Value = item.RealTurnover == 0 ? "N/A" : (object)item.RealMargin, CellAlignment = HAlignment.Right }
            };

            return new GridDataRow { Columns = columns };
        }
    }
}