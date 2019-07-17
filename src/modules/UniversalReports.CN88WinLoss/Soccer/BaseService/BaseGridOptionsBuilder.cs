using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Soccer.BaseService
{
    public class BaseGridOptionsBuilder
    {
        protected BaseGridOptionsBuilder(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            GridDataRowBuilder = gridDataRowBuilder;
        }

        protected BasicGridDataRowBuilder GridDataRowBuilder { get; }

        protected GridDataRow BuildBetTypeDataRow(WinLoss item, HAlignment alignment)
        {
            var row = GridDataRowBuilder.BuildDataRow(item, alignment);
            row.RowType = RowType.ParentLevelOne;

            return row;
        }
    }
}