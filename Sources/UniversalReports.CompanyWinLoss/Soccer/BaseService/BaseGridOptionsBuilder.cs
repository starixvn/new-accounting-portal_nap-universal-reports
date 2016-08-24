using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Soccer.BaseService
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
    }
}
