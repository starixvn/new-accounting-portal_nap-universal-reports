namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    using Fanex.Excel.Enums;
    using Fanex.Excel.Models;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using UniversalReports.CompanyWinLoss.Common.Models;

    public class BetTypesGridOptionServiceImp : BetTypesGridOptionService
    {
        public GridOptions FromWinLossModel(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                Columns = BuildHeader(),
                GroupHeaderRows = BuildGroupHeaderRows(),
                BodyRows = BuildBodyRows(winLoss.SiteWinLossSummaries),
                FooterRows = BuildFooter(winLoss),
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
                new HeaderColumns { HeaderText = "Bet Type", Width = 150, Name = "BetType", CellAlignment = HAlignment.Center, ShowCollapseExpand = true },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Variance", Width = 120, Name = "VarianceIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Extra PT", Width = 120, Name = "ExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "After Extra PT", Width = 120, Name = "AfterExtraPT", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
                new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Bet Type", Name = "BetType", MergeRowNumber = 2, Width = 150 },
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

        private List<GridDataRow> BuildBodyRows(List<WinLossSummaryByBetTypeGroup> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var winLossSummary in winLoss)
            {
                foreach (var item in winLossSummary.SiteWinLossSummaries)
                {
                    var row = BuildSportDataRow(item, HAlignment.Left);
                    bodyRows.Add(row);
                }

                var totalRow = BuildDataRow(winLossSummary.Total, HAlignment.Right);
                bodyRows.Add(totalRow);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(WinLossModel winLoss)
        {
            return new List<GridDataRow>
            {
                BuildDataRow(winLoss.MainTotal, HAlignment.Right),
                BuildDataRow(winLoss.OtherTotal, HAlignment.Right),
                BuildSportDataRow(winLoss.GrandTotal, HAlignment.Right)
            };
        }

        private GridDataRow BuildSportDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var row = BuildDataRow(item.Total, alignment);
            row.SubRows = new List<GridDataRow>
            {
                BuildDataRow(item.Credit, HAlignment.Right),
                BuildDataRow(item.Deposit, HAlignment.Right)
            };

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
                new Columns { ColumnIndex = columnIndex++, Name = "BetType", Value = string.IsNullOrEmpty(item.Name) ? string.Empty : item.Name, DisplayValue = item.Name, CellAlignment = alignment, CustomAttributes = betTypeId },
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
                new Columns(columnIndex++, "RealMargin", GetFormattedMargin(item)),
                new Columns(columnIndex++, "VirtualMargin", GetFormattedMargin(item))
            };

            return new GridDataRow { Columns = columns };
        }

        private object GetFormattedMargin(WinLoss item)
        {
            return item.RealMargin == 0 ? "N/A" : (object)item.RealMargin;
        }
    }
}
