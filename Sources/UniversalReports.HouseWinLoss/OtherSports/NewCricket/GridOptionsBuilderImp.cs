using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private readonly BasicGridDataRowBuilder gridDataRowBuilder;

        private const string CssTotal = "grand-total";

        private const string CssChargeCom = "cricket-charged-commission";

        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            this.gridDataRowBuilder = gridDataRowBuilder;
        }

        public GridOptions Build(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title.ToUpper(),
                BodyRows = BuildBodyRows(winLoss),
                FooterRows = BuildFooter(winLoss),
                ShowFooter = true,
                ShowTree = true,
                ShowHighlightRow = false,
                ShowDistinctRow = false
            };
        }

        private List<GridDataRow> BuildBodyRows(WinLossModel winLoss)
        {
            return winLoss.SiteWinLossNonChargedCom.Select(item => BuildGroupDataRow(item, HAlignment.Left)).ToList();
        }

        private List<GridDataRow> BuildFooter(WinLossModel model)
        {
            var total = BuildGroupDataRow(model.SiteWinLossChargedCom.Total, HAlignment.Right, CssTotal);
            var chargedCom = model.SiteWinLossChargedCom.Winloss.Select(item => BuildGroupDataRow(item, HAlignment.Left, CssChargeCom)).ToList();
            var grandTotal = BuildGroupDataRow(model.GrandTotal, HAlignment.Right, CssTotal);
            var allRMRows = model.RM.Select(r => gridDataRowBuilder.BuildDataRow(r, HAlignment.Right));

            var footer = new List<GridDataRow> { total };
            footer.AddRange(chargedCom);
            footer.Add(grandTotal);
            footer.AddRange(allRMRows);
            return footer;
        }

        private GridDataRow BuildGroupDataRow(SiteWinLossSummary item, HAlignment alignment, string cssStyle = "")
        {
            var row = gridDataRowBuilder.BuildDataRow(item.Total, alignment);
            row.RowType = RowType.ParentLevelOne;
            row.CssClass = cssStyle;

            var creditRow = gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            creditRow.CssClass = cssStyle;
            var depositRow = gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);
            depositRow.CssClass = cssStyle;

            row.SubRows.Add(creditRow);
            row.SubRows.Add(depositRow);

            return row;
        }
    }
}
