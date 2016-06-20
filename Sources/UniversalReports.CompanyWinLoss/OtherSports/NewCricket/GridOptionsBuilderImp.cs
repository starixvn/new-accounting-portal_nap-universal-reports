using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private readonly BasicGridDataRowBuilder gridDataRowBuilder;

        private readonly string cssChargedCom = "cricket-charged-commission";

        private readonly string cssChargedComTotal = "cricket-non-charged-com-total";

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
                TitleInfoText = title,
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
            var nonChargedCom = winLoss.SiteWinLossNonChargedCom.Select(item => BuildGroupDataRow(item, HAlignment.Left)).ToList();
            var total = BuildCharegCommission(winLoss.SiteWinLossChargedCom.Total, HAlignment.Right, cssChargedComTotal);
            var chargedCom = winLoss.SiteWinLossChargedCom.Winloss.Select(item => BuildCharegCommission(item, HAlignment.Left, cssChargedCom)).ToList();
            var bodyRows = new List<GridDataRow> { };
            bodyRows.AddRange(nonChargedCom);
            bodyRows.Add(total);
            bodyRows.AddRange(chargedCom);
            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(WinLossModel model)
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

        private GridDataRow BuildCharegCommission(SiteWinLossSummary item, HAlignment alignment, string cssStyle)
        {
            var row = gridDataRowBuilder.BuildDataRow(item.Total, alignment);
            row = BuildStyleChargedCom(row, cssStyle);

            var creditRow = gridDataRowBuilder.BuildDataRow(item.Credit, HAlignment.Right);
            var depositRow = gridDataRowBuilder.BuildDataRow(item.Deposit, HAlignment.Right);

            row.SubRows.Add(BuildStyleChargedCom(creditRow, cssStyle));
            row.SubRows.Add(BuildStyleChargedCom(depositRow, cssStyle));

            return row;
        }

        private GridDataRow BuildStyleChargedCom(GridDataRow dataRow, string cssStyle)
        {
            dataRow.RowType = RowType.SubTotal;
            dataRow.CssClass = cssStyle;
            return dataRow;
        }
    }
}
