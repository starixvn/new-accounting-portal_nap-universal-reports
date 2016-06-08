using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Soccer.BaseService;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public class GridOptionsBuilderImp : BaseGridOptionsBuilder, GridOptionsBuilder
    {
        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
            : base(gridDataRowBuilder)
        {
        }

        public GridOptions Build(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(winLoss.SiteWinLossSummaries),
                FooterRows = BuildFooter(winLoss),
                ShowFooter = true,
                ShowTree = true,
                ShowHighlightRow = false,
                ShowDistinctRow = false
            };
        }

        protected List<GridDataRow> BuildBodyRows(List<WinLossSummaryByBetTypeGroup> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var winLossSummary in winLoss)
            {
                bodyRows.AddRange(winLossSummary.SiteWinLossSummaries.Select(item => BuildBetTypeDataRow(item, HAlignment.Left)));

                var totalRow = GridDataRowBuilder.BuildDataRow(winLossSummary.Total, HAlignment.Right);
                bodyRows.Add(totalRow);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(WinLossModel winLoss)
        {
            var rows = new List<WinLoss>
            {
                winLoss.MainTotal,
                winLoss.OtherTotal,
                winLoss.HedgeTotal,
                winLoss.GrandTotal.Total,
                winLoss.GrandTotal.Credit,
                winLoss.GrandTotal.Deposit
            };

            rows.AddRange(winLoss.RM);
            return rows
                .Where(r => r.RealTurnover != 0 || r.VirtualTurnover != 0)
                .Select(r => GridDataRowBuilder.BuildDataRow(r, HAlignment.Right))
                       .ToList();
        }
    }
}
