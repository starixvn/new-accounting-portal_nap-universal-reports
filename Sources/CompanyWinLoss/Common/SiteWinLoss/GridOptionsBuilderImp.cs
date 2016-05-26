using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private BasicGridDataRowBuilder gridDataRowBuilder;

        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            this.gridDataRowBuilder = gridDataRowBuilder;
        }

        public GridOptions Build(SiteWinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleInfoText = title,
                TitleType = TitleType.TwoLineBlue,
                BodyRows = BuildBodyRows(winLoss.Sites),
                FooterRows = BuildFooter(winLoss.Total),
                ShowFooter = true
            };
        }

        private List<GridDataRow> BuildBodyRows(List<WinLoss> winLoss)
        {
            return winLoss.Select(item => gridDataRowBuilder.BuildDataRow(item, HAlignment.Center)).ToList();
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            return new List<GridDataRow> { gridDataRowBuilder.BuildDataRow(item, HAlignment.Center) };
        }
    }
}