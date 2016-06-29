using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.BasicWinLoss
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

        private List<GridDataRow> BuildFooter(BasicWinLossModel model)
        {
            var row = gridDataRowBuilder.BuildDataRow(model.GrandTotal.Total, HAlignment.Right);
            var creditRow = gridDataRowBuilder.BuildDataRow(model.GrandTotal.Credit, HAlignment.Right);
            var depositRow = gridDataRowBuilder.BuildDataRow(model.GrandTotal.Deposit, HAlignment.Right);
            var allRMRows = model.RM.Select(r => gridDataRowBuilder.BuildDataRow(r, HAlignment.Right));

            var footer = new List<GridDataRow> { row, creditRow, depositRow };
            footer.AddRange(allRMRows);

            return footer;
        }

        private GridDataRow BuildGroupDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var row = gridDataRowBuilder.BuildDataRow(item.Total, alignment);
            row.RowType = RowType.ParentLevelOne;

            var creditRow = gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);

            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

            return row;
        }
    }
}