using System.Collections.Generic;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    public class BasicGridOptionsBuilderImp : BasicGridOptionsBuilder
    {
        private readonly BasicGridDataRowBuilder gridDataRowBuilder;

        public BasicGridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            this.gridDataRowBuilder = gridDataRowBuilder;
        }

        public GridOptions Build(BasicWinLossModel winLoss, string title)
        {
            return new GridOptions
            {
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

        private List<GridDataRow> BuildBodyRows(IEnumerable<SiteWinLossSummary> winLoss)
        {
            return winLoss.Select(item => BuildGroupDataRow(item, HAlignment.Left)).ToList();
        }

        protected virtual List<GridDataRow> BuildFooter(BasicWinLossModel model)
        {
            var row = BuildTotalGroupDataRow(model.GrandTotal);
            var allRMRows = model.RM.Select(r => gridDataRowBuilder.BuildDataRow(r, HAlignment.Right));

            var footer = new List<GridDataRow> { row };
            footer.AddRange(allRMRows);

            return footer;
        }

        protected virtual GridDataRow BuildGroupDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var row = gridDataRowBuilder.BuildDataRow(item.Total, alignment);
            row.RowType = RowType.ParentLevelOne;

            var creditRow = gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);

            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

            return row;
        }

        protected virtual GridDataRow BuildTotalGroupDataRow(SiteWinLossSummary item)
        {
            var row = gridDataRowBuilder.BuildDataRow(item.Total, HAlignment.Right);
            row.RowType = RowType.ParentLevelOne;
            row.CssClass = "grand-total";

            var creditRow = gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            creditRow.CssClass = "grand-total";

            var depositRow = gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);
            depositRow.CssClass = "grand-total";

            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

            return row;
        }
    }
}