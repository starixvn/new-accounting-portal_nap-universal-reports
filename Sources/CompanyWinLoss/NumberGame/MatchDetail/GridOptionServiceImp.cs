using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public class GridOptionServiceImp : GridOptionService
    {
        public GridOptions FromWinLossModel(WinLossModel winLoss, string breadCrumb)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleInfoText = breadCrumb,
                TitleType = TitleType.TwoLineBlue,
                Columns = BuildHeader(),
                GroupHeaderRows = BuildGroupHeaderRows(),
                BodyRows = BuildBodyRows(winLoss.Leagues),
                FooterRows = BuildFooter(winLoss.Total),
                ShowFooter = true
            };
        }

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
          "SP2100:CodeLineMustNotBeLongerThan",
          Justification = "Reviewed. Suppression is OK here.")]
        private List<HeaderColumns> BuildHeader()
        {
            var header = new List<HeaderColumns>();
            header.AddRange(
                new List<HeaderColumns>
                {
                    new HeaderColumns { HeaderText = "Code", Width = 150, Name = "Code", HeaderAlign = "center", CellAlignment = HAlignment.Center },
                    new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                    new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealIncome", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                    new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualIncome", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                    new HeaderColumns { HeaderText = "Variance", Width = 120, Name = "Variance", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealTurnover", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualTurnover", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                    new HeaderColumns { HeaderText = "Real", Width = 120, Name = "RealMargin", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive },
                    new HeaderColumns { HeaderText = "Virtual", Width = 120, Name = "VirtualMargin", HeaderAlign = "center", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
                });

            return header;
        }

        private List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            List<GroupHeaderRows> groupHeaderRows = new List<GroupHeaderRows>();

            var groupHeader = new GroupHeaderRows();
            groupHeader.Columns.AddRange(
                new List<HeaderColumns>
                {
                    new HeaderColumns { HeaderText = "Code", Name = "Code", MergeRowNumber = 2, Width = 150 },
                    new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Commission", Name = "Commission", MergeRowNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome", MergeColNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover", MergeColNumber = 2, Width = 120 },
                    new HeaderColumns { HeaderText = "Margin", Name = "RealMargin", MergeColNumber = 2, Width = 120 }
                });

            groupHeaderRows.Add(groupHeader);
            return groupHeaderRows;
        }

        private List<GridDataRow> BuildBodyRows(List<LeagueWinLoss> leagues)
        {
            var bodyRows = new List<GridDataRow>();
            foreach (var league in leagues)
            {
                var rows = BuildLeagues(league);
                bodyRows.AddRange(rows);
            }

            return bodyRows;
        }

        private List<GridDataRow> BuildLeagues(LeagueWinLoss league)
        {
            var leagueNameRow = BuildLeagueNameRow(league.Name);

            var matchRows = league.Matches.Select(m => BuildDataRow(m, HAlignment.Center));
            var rows = new List<GridDataRow> { leagueNameRow };
            rows.AddRange(matchRows);

            return rows;
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "Code", item.Name, alignment),
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealMargin", item.RealMargin),
                new Columns(columnIndex++, "VirtualMargin", item.VirtualMargin)
            };

            return new GridDataRow { Columns = columns };
        }

        private GridDataRow BuildLeagueNameRow(string leagueName)
        {
            return new GridDataRow
            {
                Columns = new List<Columns>
               {
                    new Columns(0, "Code", string.Empty),
                    new Columns { ColumnIndex = 1, Name = "MemberWinLoss", Value = leagueName, MergeColNumber = 10 }
               }
            };
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            var footerRow = new List<GridDataRow>();
            footerRow.Add(BuildDataRow(item, HAlignment.Right));
            return footerRow;
        }
    }
}