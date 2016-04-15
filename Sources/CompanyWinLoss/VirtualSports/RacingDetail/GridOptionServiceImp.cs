using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingDetail
{
    public class GridOptionServiceImp : GridOptionService
    {
        public GridOptions FromWinLossModel(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleInfoText = title,
                TitleType = TitleType.TwoLineBlue,
                Columns = BuildHeader(),
                BodyRows = BuildBodyRows(winLoss.Matches),
                FooterRows = BuildFooter(winLoss.Total),
                ShowFooter = true
            };
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        private List<HeaderColumns> BuildHeader()
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = string.Empty, Width = 150, Name = "Race", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "RealMargin", Width = 120, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
            };
        }

        private List<GridDataRow> BuildBodyRows(List<WinLoss> matches)
        {
            return matches.Select(m => BuildDataRow(m, HAlignment.Center)).ToList();
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "Race", item.Name, alignment),
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex, "RealMargin", item.RealMargin),
            };

            return new GridDataRow { Columns = columns };
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            return new List<GridDataRow> { BuildDataRow(item, HAlignment.Right) };
        }
    }
}