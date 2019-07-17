using System.Collections.Generic;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }

    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private const string CssTotal = "grand-total";
        private const string CssChargeCom = "cricket-charged-commission";
        private readonly BasicGridDataRowBuilder gridDataRowBuilder;

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
                TitleInfoText = title.ToUpperInvariant(),
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
            return winLoss.WinLossNonChargedCom.Select(item => BuildDataRow(item, HAlignment.Left)).ToList();
        }

        private List<GridDataRow> BuildFooter(WinLossModel model)
        {
            var total = BuildDataRow(model.WinLossChargedCom.Total, HAlignment.Right, CssTotal);
            var chargedCom = model.WinLossChargedCom.Winloss.Select(item => BuildDataRow(item, HAlignment.Left, CssChargeCom)).ToList();
            var grandTotal = BuildDataRow(model.GrandTotal, HAlignment.Right, CssTotal);

            var footer = new List<GridDataRow> { total };
            footer.AddRange(chargedCom);
            footer.Add(grandTotal);
            return footer;
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment, string cssStyle = "")
        {
            var row = gridDataRowBuilder.BuildDataRow(item, alignment);
            row.RowType = RowType.ParentLevelOne;
            row.CssClass = cssStyle;

            return row;
        }
    }
}