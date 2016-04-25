using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Soccer.BetType;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public class GridOptionBuilderImp : BaseGridOptions, GridOptionBuilder
    {
        public GridOptions FromWinLossModel(WinLossModel winLoss, string title)
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

        private List<GridDataRow> BuildBodyRows(List<SiteWinLossSummary> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var item in winLoss)
            {
                var row = BuildBetTypeDataRow(item, HAlignment.Left);
                bodyRows.Add(row);
            }

            return bodyRows;
        }
    }
}
