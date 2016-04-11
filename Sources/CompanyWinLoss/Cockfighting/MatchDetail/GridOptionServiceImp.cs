using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class GridOptionServiceImp : GridOptionService
    {
        public GridOptions FromWinLossModel(WinLossModel winloss, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleInfoText = title,
                TitleType = TitleType.TwoLineBlue,
                Columns = BuildHeader(),
                GroupHeaderRows = BuildGroupHeaderRows(),
                BodyRows = BuildBodyRows(winloss.Arenas),
                FooterRows = BuildFooter(winloss.Total),
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
                new HeaderColumns { HeaderText = "Fight No.", Width = 100, Name = "FightNo", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 120, Name = "Home", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 20, Name = "VS", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = string.Empty, Width = 120, Name = "Away", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "Margin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
        }

        private List<GroupHeaderRows> BuildGroupHeaderRows()
        {
            var columns = new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Fight No.", Name = "FightNo", Width = 100, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Event", Name = "Home", Width = 260, MergeColNumber = 3, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Member Win Loss", Name = "MemberWinLoss", Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "SMA Win Loss", Name = "SMAWinLoss",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Commission", Name = "Commission",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Company Income", Name = "RealIncome",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Company Turnover", Name = "RealTurnover",  Width = 120, MergeRowNumber = 2 },
                new HeaderColumns { HeaderText = "Margin", Name = "Margin",  Width = 120, MergeRowNumber = 2 }
            };

            var groupHeader = new GroupHeaderRows { Columns = columns };
            return new List<GroupHeaderRows> { groupHeader };
        }

        private List<GridDataRow> BuildBodyRows(List<LeagueWinLoss> arenaWinLoss)
        {
            List<List<GridDataRow>> gridDataRows = new List<List<GridDataRow>>();
            foreach (var arena in arenaWinLoss)
            {
                var arenaRows = BuildArenaDataRows(arena);
                gridDataRows.Add(arenaRows);
            }

            return gridDataRows.SelectMany(x => x).ToList();
        }

        private List<GridDataRow> BuildArenaDataRows(LeagueWinLoss arena)
        {
            List<GridDataRow> dataRows = new List<GridDataRow>();

            var arenaNameRow = BuildArenaNameRow(arena.LeagueName);
            dataRows.Add(arenaNameRow);

            foreach (var item in arena.Matches)
            {
                var row = BuidDataRow(item);
                dataRows.Add(row);
            }

            if (arena.Matches.Count > 1)
            {
                var arenaTotalRow = BuildArenalTotalRow(arena.Total);
                dataRows.Add(arenaTotalRow);
            }

            return dataRows;
        }

        private GridDataRow BuidDataRow(MatchDetailWinLoss item)
        {
            int columnIndex = 0;
            var colummns = new List<Columns>
               {
                    new Columns(columnIndex++, "FightNo", item.MatchCode),
                    new Columns(columnIndex++, "Home", item.HomeName),
                    new Columns(columnIndex++, "VS", "-vs-"),
                    new Columns(columnIndex++, "Away", item.AwayName),
                    new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                    new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                    new Columns(columnIndex++, "Commission", item.Commission),
                    new Columns(columnIndex++, "RealIncome", item.RealIncome),
                    new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                    new Columns(columnIndex++, "Margin", item.Margin)
               };

            return new GridDataRow { Columns = colummns };
        }

        private GridDataRow BuildArenaNameRow(string arenaName)
        {
            int columnIndex = 0;
            var colummns = new List<Columns>
               {
                    new Columns { ColumnIndex = columnIndex++, Name = "FightNo", Value = string.Empty },
                    new Columns { ColumnIndex = columnIndex++, Name = "MemberWinLoss", Value = arenaName, MergeColNumber = 9, Bold = true }
               };

            return new GridDataRow { Columns = colummns };
        }

        private GridDataRow BuildArenalTotalRow(MatchDetailWinLoss total)
        {
            int startColumnIndex = 0;
            int columnIndex = 4;
            var colummns = new List<Columns>
               {
                    new Columns { ColumnIndex = startColumnIndex, Name = "FightNo", Value = string.Empty, MergeColNumber = 4 },
                    new Columns(columnIndex++, "MemberWinLoss", total.MemberWinLoss),
                    new Columns(columnIndex++, "SMAWinLoss", total.SMAWinLoss),
                    new Columns(columnIndex++, "Commission", total.Commission),
                    new Columns(columnIndex++, "RealIncome", total.RealIncome),
                    new Columns(columnIndex++, "RealTurnover", total.RealTurnover),
                    new Columns(columnIndex++, "Margin", total.Margin)
               };

            return new GridDataRow { Columns = colummns };
        }

        private List<GridDataRow> BuildFooter(MatchDetailWinLoss total)
        {
            int startColumnIndex = 0;
            int columnIndex = 4;
            var colummns = new List<Columns>
               {
                    new Columns { ColumnIndex = startColumnIndex, Name = "FightNo", Value = "Cockfighting Total", MergeColNumber = 4, CellAlignment = HAlignment.Right },
                    new Columns(columnIndex++, "MemberWinLoss", total.MemberWinLoss),
                    new Columns(columnIndex++, "SMAWinLoss", total.SMAWinLoss),
                    new Columns(columnIndex++, "Commission", total.Commission),
                    new Columns(columnIndex++, "RealIncome", total.RealIncome),
                    new Columns(columnIndex++, "RealTurnover", total.RealTurnover),
                    new Columns(columnIndex++, "Margin", total.Margin)
               };

            var row = new GridDataRow { Columns = colummns };
            return new List<GridDataRow> { row };
        }
    }
}