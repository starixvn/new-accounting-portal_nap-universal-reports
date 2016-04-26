using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailByCode
{
    public class GridOptionBuilderImp : GridOptionBuilder
    {
        public GridOptions Build(WinLossModel winLoss, string title)
        {
            var gridOptions = new GridOptions
            {
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(winLoss.Leagues),
                FooterRows = BuildFooter(winLoss.Total),
                ShowFooter = true,
                ShowDistinctRow = false
            };

            return gridOptions;
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
            var totalRows = BuildDataRow(league.Total, HAlignment.Right);

            var rows = new List<GridDataRow> { leagueNameRow };
            rows.AddRange(matchRows);
            rows.Add(totalRows);

            return rows;
        }

        private GridDataRow BuildDataRow(WinLoss item, HAlignment alignment)
        {
            int columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "MatchCode", item.Name, alignment),
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
            int columnIndex = 0;
            var colummns = new List<Columns>
               {
                    new Columns { ColumnIndex = columnIndex, Name = "MatchCode", Value = leagueName, MergeColNumber = 7, Bold = true, CellAlignment = HAlignment.Left }
               };

            return new GridDataRow { Columns = colummns, RowType = RowType.ParentLevelOne, CssClass = "league-match-header" };
        }

        private List<GridDataRow> BuildFooter(WinLoss item)
        {
            return new List<GridDataRow> { BuildDataRow(item, HAlignment.Right) };
        }
    }
}