using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailByCode
{
    public class GridOptionBuilderImp : GridOptionBuilder
    {
        public GridOptions Build(WinLossModel winLoss, string title)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                Columns = BuildHeader(),
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
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Code", Width = 150, Name = "Code", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "Member Win Loss", Width = 120, Name = "MemberWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "SMA Win Loss", Width = 120, Name = "SMAWinLoss", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Commission", Width = 120, Name = "Commission", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Income", Width = 120, Name = "RealIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedPositive },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 120, Name = "RealTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Margin", Width = 120, Name = "RealMargin", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedPositive }
            };
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
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex, "RealMargin", item.RealTurnover == 0 ? "N/A" : (object)item.RealMargin)
            };

            return new GridDataRow { Columns = columns };
        }

        private GridDataRow BuildLeagueNameRow(string leagueName)
        {
            return new GridDataRow
            {
                Columns = new List<Columns>
                {
                    new Columns { ColumnIndex = 0, Name = "Code", Value = leagueName, MergeColNumber = 7, CssClass = "league-header" }
                }
            };
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            return new List<GridDataRow> { BuildDataRow(item, HAlignment.Right) };
        }
    }
}