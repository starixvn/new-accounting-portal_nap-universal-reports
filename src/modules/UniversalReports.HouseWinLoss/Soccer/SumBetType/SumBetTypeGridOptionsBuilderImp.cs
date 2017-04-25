using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Soccer.BaseService;

namespace UniversalReports.HouseWinLoss.Soccer.SumBetType
{
    public interface SumBetTypeGridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }

    public class SumBetTypeGridOptionsBuilderImp : BaseBetTypeGridOptionsBuilder, SumBetTypeGridOptionsBuilder
    {
        public SumBetTypeGridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
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
    }
}