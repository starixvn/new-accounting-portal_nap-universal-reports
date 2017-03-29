using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Soccer.BaseService;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }

    public class GridOptionsBuilderImp : BaseGridOptionsBuilder, GridOptionsBuilder
    {
        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
            : base(gridDataRowBuilder)
        {
        }

        public GridOptions Build(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title.ToUpper(),
                BodyRows = BuildBodyRows(winLoss.SiteWinLossSummaries),
                FooterRows = BuildFooter(winLoss),
                ShowFooter = true,
                ShowTree = true,
                ShowHighlightRow = false,
                ShowDistinctRow = false
            };
        }

        private List<GridDataRow> BuildBodyRows(List<WinLossSummaryByBetTypeGroup> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var winLossSummary in winLoss)
            {
                var rows = winLossSummary
                    .SiteWinLossSummaries
                    .Select(item => BuildBetTypeDataRow(item, HAlignment.Left));
                var totalRow = GridDataRowBuilder.BuildDataRow(winLossSummary.Total, HAlignment.Right);
                totalRow.RowType = RowType.SubTotal;
                totalRow.CssClass = "total-row";
                bodyRows.AddRange(rows);
                bodyRows.Add(totalRow);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(WinLossModel winLoss)
        {
            var rows = new List<WinLoss>
            {
                winLoss.MainTotal,
                winLoss.OtherTotal,
                winLoss.HedgeTotal
            };

            var footer = BuildRowsFooter(rows);
            footer.Add(BuildGrandTotal(winLoss.GrandTotal));
            footer.AddRange(BuildRowsFooter(winLoss.RM));
            rows.AddRange(winLoss.RM);

            return footer;
        }

        private List<GridDataRow> BuildRowsFooter(IEnumerable<WinLoss> rows)
        {
            return rows
                .Where(r => r.RealTurnover != 0 || r.VirtualTurnover != 0)
                .Select(r => GridDataRowBuilder.BuildDataRow(r, HAlignment.Right))
                .ToList();
        }

        private GridDataRow BuildGrandTotal(SiteWinLossSummary item)
        {
            var row = GridDataRowBuilder.BuildDataRow(item.Total, HAlignment.Right);
            row.RowType = RowType.ParentLevelOne;
            row.CssClass = "grand-total";

            var creditRow = GridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            creditRow.CssClass = "grand-total";

            var depositRow = GridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);
            depositRow.CssClass = "grand-total";

            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

            return row;
        }
    }
}