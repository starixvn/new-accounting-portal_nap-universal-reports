using System.Collections.Generic;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Soccer.BaseService
{
    public class BaseBetTypeGridOptionsBuilder : BaseGridOptionsBuilder
    {
        protected BaseBetTypeGridOptionsBuilder(BasicGridDataRowBuilder gridDataRowBuilder) : base(gridDataRowBuilder)
        {
        }

        protected List<GridDataRow> BuildFooter(BaseBetTypeWinLossModel winLoss)
        {
            var rows = new List<WinLoss>
            {
                winLoss.MainTotal,
                winLoss.OtherTotal
            };

            var footer = BuildRowsFooter(rows);
            footer.Add(BuildGrandTotal(winLoss.GrandTotal));

            return footer;
        }

        protected List<GridDataRow> BuildRowsFooter(IEnumerable<WinLoss> rows)
        {
            return rows
                .Where(r => r.RealTurnover != 0 || r.VirtualTurnover != 0)
                .Select(r => GridDataRowBuilder.BuildDataRow(r, HAlignment.Right))
                .ToList();
        }

        protected GridDataRow BuildGrandTotal(WinLoss item)
        {
            var row = GridDataRowBuilder.BuildDataRow(item, HAlignment.Right);
            row.RowType = RowType.ParentLevelOne;
            row.CssClass = "grand-total";

            return row;
        }
    }
}