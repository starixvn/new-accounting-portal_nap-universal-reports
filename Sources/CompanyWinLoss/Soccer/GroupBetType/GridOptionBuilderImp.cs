using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Soccer.BetType;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public class GridOptionBuilderImp : BaseGridOptions, GridOptionBuilder
    {
        public GridOptions Build(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                Columns = BuildHeader(),
                GroupHeaderRows = BuildGroupHeaderRows(),
                BodyRows = BuildBodyRows(winLoss.SiteWinLossSummaries),
                FooterRows = BuildFooter(winLoss.MainTotal, winLoss.OtherTotal, winLoss.GrandTotal, winLoss.RM),
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

                var totalRow = BuildDataRow(winLossSummary.Total, HAlignment.Right);
                bodyRows.Add(totalRow);
            }

            return bodyRows;
        }
    }
}
