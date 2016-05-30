using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    public class BaseGridOptionsBuilder
    {
        public BaseGridOptionsBuilder(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            GridDataRowBuilder = gridDataRowBuilder;
        }

        protected BasicGridDataRowBuilder GridDataRowBuilder { get; }

        protected GridDataRow BuildBetTypeDataRow(SiteWinLossSummary item, HAlignment alignment)
        {
            var row = GridDataRowBuilder.BuildDataRow(item.Total, alignment);
            row.RowType = RowType.ParentLevelOne;

            row.SubRows = new List<GridDataRow>
            {
                GridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right),
                GridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right)
            };

            return row;
        }

        protected object GetFormattedMargin(WinLoss item)
        {
            return item.RealMargin == 0 ? "N/A" : (object)item.RealMargin;
        }

        protected List<GridDataRow> BuildFooter(WinLoss mainTotal, WinLoss otherTotal, SiteWinLossSummary grandTotal, List<WinLoss> rM)
        {
            var footer = new List<GridDataRow>
            {
                GridDataRowBuilder.BuildDataRow(mainTotal, HAlignment.Right),
                GridDataRowBuilder.BuildDataRow(otherTotal, HAlignment.Right),
                GridDataRowBuilder.BuildDataRow(grandTotal.Total, HAlignment.Right),
                GridDataRowBuilder.BuildDataRow(grandTotal.Credit, HAlignment.Right),
                GridDataRowBuilder.BuildDataRow(grandTotal.Deposit, HAlignment.Right)
            };

            var allRMRows = rM.Select(r => GridDataRowBuilder.BuildDataRow(r, HAlignment.Right));
            footer.AddRange(allRMRows);

            return footer;
        }
    }
}
