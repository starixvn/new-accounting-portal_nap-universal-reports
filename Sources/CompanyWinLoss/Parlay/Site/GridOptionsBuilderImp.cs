using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private BasicGridDataRowBuilder gridDataRowBuilder;

        public GridOptionsBuilderImp(BasicGridDataRowBuilder gridDataRowBuilder)
        {
            this.gridDataRowBuilder = gridDataRowBuilder;
        }

        public GridOptions Build(SiteParlayModel winLoss, string title)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleInfoText = title,
                TitleType = TitleType.TwoLineBlue,
                BodyRows = BuildSites(winLoss.Sites),
                FooterRows = BuildFooter(winLoss.Total),
                ShowFooter = true
            };
        }

        private List<GridDataRow> BuildSites(List<SiteModel> sites)
        {
            List<GridDataRow> sitesResult = new List<GridDataRow>();
            foreach (var group in sites)
            {
                sitesResult.AddRange(BuildBodyRows(group.Sites).ToList());
                var total = gridDataRowBuilder.BuildDataRow(group.Total, HAlignment.Center);
                total.CssClass = "total-row";
                sitesResult.Add(total);
                sitesResult.Add(new GridDataRow());
            }

            return sitesResult;
        }

        private List<GridDataRow> BuildBodyRows(List<WinLoss> winLoss)
        {
            return winLoss.Select(item => gridDataRowBuilder.BuildDataRow(item, HAlignment.Center)).ToList();
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            return new List<GridDataRow> { gridDataRowBuilder.BuildDataRow(item, HAlignment.Right) };
        }
    }
}