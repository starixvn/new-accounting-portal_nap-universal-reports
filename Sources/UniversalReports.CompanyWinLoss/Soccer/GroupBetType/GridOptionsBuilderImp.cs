using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Soccer.BaseService;
using UniversalReports.CompanyWinLoss.Soccer.BetType;

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

                var totalRow = GridDataRowBuilder.BuildDataRow(winLossSummary.Total, HAlignment.Right);
                bodyRows.Add(totalRow);
            }

            return bodyRows;
        }
    }
}
