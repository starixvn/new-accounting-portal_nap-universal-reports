using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Soccer.BaseService;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public class GridOptionsBuilderImp : BaseGridOptionsBuilder, GridOptionsBuilder
    {
        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
           : base(gridDataRowBuilder)
        {
        }

        public GridOptions FromWinLossModel(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
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
            return winLoss
                .Select(item => BuildBetTypeDataRow(item, HAlignment.Left))
                .ToList();
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
