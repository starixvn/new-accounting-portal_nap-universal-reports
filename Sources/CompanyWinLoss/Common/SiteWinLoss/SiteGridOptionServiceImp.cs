using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Extensions;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public class SiteGridOptionServiceImp : SiteGridOptionService
    {
        public GridOptions FromWinLossModel(SiteWinLossModel winLoss, string title)
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
            return winLoss.Select(item => BuildDataRow(item, HAlignment.Center)).ToList();
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            return new List<GridDataRow> { BuildDataRow(item, HAlignment.Right) };
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "Main", item.Name, alignment),
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "ExtraPT", item.ExtraPT),
                new Columns(columnIndex++, "AfterExtraPT", item.AfterExtraPT),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualMargin", item.ExcelVirtualMargin()),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };

            return new GridDataRow { Columns = columns };
        }
    }
}