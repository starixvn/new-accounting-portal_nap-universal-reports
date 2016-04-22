using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Extensions;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
{
    public class BasicGridOptionBuilderImp : BasicGridOptionBuilder
    {
        public GridOptions Build(BasicWinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(winLoss.SiteWinLossSummaries),
                FooterRows = BuildFooter(winLoss),
                ShowFooter = true,
                ShowTree = true,
                ShowHighlightRow = false,
                ShowDistinctRow = false
            };
        }

        private List<GridDataRow> BuildBodyRows(List<SiteWinLossSummary> winLoss)
        {
            return winLoss.Select(item => BuildBetTypeDataRow(item, HAlignment.Left)).ToList();
        }

        private List<GridDataRow> BuildFooter(BasicWinLossModel model)
        {
            var row = BuildDataRow(model.GrandTotal.Total, HAlignment.Right);
            var creditRow = BuildDataRow(model.GrandTotal.Credit, HAlignment.Right);
            var depositRow = BuildDataRow(model.GrandTotal.Deposit, HAlignment.Right);
            var allRMRows = model.RM != null ? model.RM.Select(r => BuildDataRow(r, HAlignment.Right)) : null;

            var footer = new List<GridDataRow> { row, creditRow, depositRow };

            if (allRMRows != null) { footer.AddRange(allRMRows); }
            return footer;
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
                new Columns { ColumnIndex = columnIndex++, Name = "Main", Value = string.IsNullOrEmpty(item.Name) ? string.Empty : item.Name, DisplayValue = item.Name, CustomAttributes = betTypeId, CellAlignment = alignment },
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "ExtraPT", item.ExtraPT),
                new Columns(columnIndex++, "AfterExtraPT", item.AfterExtraPT),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualMargin", item.ExcelVirtualMargin()),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };

            return new GridDataRow { Columns = columns };
        }
    }
}