using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class GridOptionServiceImp : GridOptionService
    {
        public GridOptions FromWinLossModel(WinLossModel winLoss)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                Columns = BuildHeader(),
                GroupHeaderRows = BuildGroupHeaderRows(),
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
                new HeaderColumns { HeaderText = "Code", Width = 150, Name = "Code", HeaderAlign = "center", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 120, Name = "Home", HeaderAlign = "center", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 20, Name = "VS", HeaderAlign = "center", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 120, Name = "Away", HeaderAlign = "center", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "Margin", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Name = "Code", Width = 150 },
                new HeaderColumns { HeaderText = "Event", Name = "Home", Width = 260, MergeColNumber = 3 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 120 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss",  Width = 120 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission",  Width = 120 },
                new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome",  Width = 120 },
                new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover",  Width = 120 },
                new HeaderColumns { HeaderText = "Margin", Name = "Margin",  Width = 120 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }

        private List<GridDataRow> BuildBodyRows(List<WinLoss> winLoss)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var item in winLoss)
            {
                var row = BuildDataRow(item, HAlignment.Center);
                bodyRows.Add(row);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            int columnIndex = 4;
            var colummns = new List<Columns>
            {
                new Columns { ColumnIndex = 0, Name = "Code", Value = "Grand Total", CellAlignment = HAlignment.Right, MergeColNumber = 4 },
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "Margin", item.Margin)
            };

            var row = new GridDataRow { Columns = colummns };
            return new List<GridDataRow> { row };
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var colummns = new List<Columns>
               {
                    new Columns(columnIndex++, "Code", item.MatchCode, alignment),
                    new Columns(columnIndex++, "Home", item.HomeName, alignment),
                    new Columns(columnIndex++, "VS", "-vs-", alignment),
                    new Columns(columnIndex++, "Away", item.AwayName, alignment),
                    new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                    new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                    new Columns(columnIndex++, "Commission", item.Commission),
                    new Columns(columnIndex++, "RealIncome", item.RealIncome),
                    new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                    new Columns(columnIndex++, "Margin", item.Margin)
               };

            return new GridDataRow { Columns = colummns };
        }
    }
}
