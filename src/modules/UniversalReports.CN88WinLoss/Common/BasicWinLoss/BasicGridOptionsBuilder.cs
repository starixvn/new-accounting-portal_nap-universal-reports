using System.Collections.Generic;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Common.BasicWinLoss
{
    public interface BasicGridOptionsBuilder
    {
        GridOptions Build(BasicWinLossModel winLoss, string title);
    }

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
                TitleInfoText = title.ToUpperInvariant(),
                BodyRows = BuildBodyRows(winLoss.WinLosses),
                FooterRows = BuildFooter(winLoss),
                ShowFooter = true,
                ShowTree = true,
                ShowHighlightRow = false,
                ShowDistinctRow = false
            };
        }

        private List<GridDataRow> BuildBodyRows(IEnumerable<WinLoss> winLoss)
        {
            return winLoss.Select(item => BuildDataRow(item, HAlignment.Left)).ToList();
        }

        private List<GridDataRow> BuildFooter(BasicWinLossModel model)
        {
            var row = BuildTotalDataRow(model.GrandTotal);
            var footer = new List<GridDataRow> { row };
            return footer;
        }

        protected virtual GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            var row = gridDataRowBuilder.BuildDataRow(item, alignment);
            row.RowType = RowType.ParentLevelOne;

            return row;
        }

        private GridDataRow BuildTotalDataRow(WinLoss item)
        {
            var row = gridDataRowBuilder.BuildDataRow(item, HAlignment.Right);
            row.RowType = RowType.ParentLevelOne;
            row.CssClass = "grand-total";

            return row;
        }
    }
}