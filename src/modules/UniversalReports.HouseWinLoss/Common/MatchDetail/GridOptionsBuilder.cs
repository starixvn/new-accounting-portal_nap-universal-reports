using System.Collections.Generic;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.HouseWinLoss.Common.Extensions;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(WinLossModel winLoss, string title);
    }

    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private readonly GetTeamNameAndSuffixService teamNameService;

        private readonly List<int> notDisplayHomeAwaySportTypeList = new List<int> { SportTypeConstants.VirtualDogRacing, SportTypeConstants.VirtualHorseRacing };

        public GridOptionsBuilderImp(GetTeamNameAndSuffixService teamNameService)
        {
            this.teamNameService = teamNameService;
        }

        public GridOptions Build(WinLossModel winLoss, string title)
        {
            var gridOptions = new GridOptions
            {
                ShowTitle = true,
                TitleInfoText = title.ToUpperInvariant(),
                TitleType = TitleType.TwoLineBlue,
                BodyRows = BuildBodyRows(winLoss.Leagues),
                FooterRows = BuildFooter(winLoss),
                ShowFooter = true,
                ShowDistinctRow = false,
                TotalItems = winLoss.TotalRows
            };

            return gridOptions;
        }

        private List<GridDataRow> BuildBodyRows(IEnumerable<LeagueWinLoss> leagueWinLoss)
        {
            var gridDataRows = leagueWinLoss.Select(BuildLeagueDataRows).ToList();

            return gridDataRows.SelectMany(x => x).ToList();
        }

        private List<GridDataRow> BuildLeagueDataRows(LeagueWinLoss league)
        {
            var dataRows = new List<GridDataRow>();
            var leagueNameRow = BuildLeagueNameRow(league.LeagueName);
            var matchRows = league.Matches.Select(m => BuidMatchRow(m, league.LeagueName));

            dataRows.Add(leagueNameRow);
            dataRows.AddRange(matchRows);

            var leagueTotalRow = BuildTotalRow(league.Total, "Total");
            leagueTotalRow.CssClass = "total-row";
            leagueTotalRow.RowType = RowType.SubTotal;
            dataRows.Add(leagueTotalRow);

            return dataRows;
        }

        private GridDataRow BuildLeagueNameRow(string leagueName)
        {
            var columnIndex = 0;
            var colummns = new List<Columns>
            {
                new Columns(columnIndex++, "MatchCode", string.Empty),
                new Columns
                {
                    ColumnIndex = columnIndex,
                    Name = "Home",
                    Value = leagueName,
                    MergeColNumber = 14,
                    Bold = true,
                    CellAlignment = HAlignment.Left
                }
            };

            return new GridDataRow
            {
                Columns = colummns,
                RowType = RowType.ParentLevelOne,
                CssClass = "league-match-header"
            };
        }

        private GridDataRow BuidMatchRow(WinLoss item, string leagueName)
        {
            var homeName = teamNameService.GetTeamNameWithSuffixByMatchCode(item.HomeName, item.MatchCode);
            var awayName = teamNameService.GetTeamNameWithSuffixByMatchCode(item.AwayName, item.MatchCode);

            var columnIndex = 0;
            var customAttributes = $"{item.SportType},{item.MatchId},'{item.EventDate:MMM dd, yyyy}','{leagueName}','{item.MatchCode}'";
            var colummns = new List<Columns>
            {
                new Columns(0, "MatchCode", item.MatchCode)
                {
                    CustomAttributes = customAttributes,
                    Bold = true,
                    CssClass = "league-match-code",
                    CellAlignment = HAlignment.Center
                }
            };
            var baseColumns = new List<Columns>();
            if (notDisplayHomeAwaySportTypeList.Contains(item.SportType))
            {
                colummns.Add(new Columns(columnIndex++, "Home", item.MatchId) { CellAlignment = HAlignment.Center });
                baseColumns = CreateBaseColumnsForNotDisplayHomeAway(columnIndex, item);
            }
            else
            {
                colummns.Add(new Columns(columnIndex++, "Home", homeName));
                colummns.Add(new Columns(columnIndex++, "VS", "-vs-") { CellAlignment = HAlignment.Center });
                colummns.Add(new Columns(columnIndex++, "Away", awayName) { CellAlignment = HAlignment.Left });
                baseColumns = CreateBaseColumns(columnIndex, item);
            }
            colummns.AddRange(baseColumns);

            return new GridDataRow
            {
                Columns = colummns,
                RowType = RowType.Normal
            };
        }

        private List<GridDataRow> BuildFooter(WinLossModel model)
        {
            var totalRow = BuildTotalRow(model.Total, "Grand Total");
            var allRMRows = model.RM.Select(r => BuildTotalRow(r, r.MatchCode));
            var result = new List<GridDataRow> { totalRow };
            result.AddRange(allRMRows);

            return result;
        }

        private GridDataRow BuildTotalRow(WinLoss item, string totalText)
        {
            var baseColumnIndex = notDisplayHomeAwaySportTypeList.Contains(item.SportType) ? 2 : 4;
            var colummns = new List<Columns>
            {
                new Columns
                {
                    ColumnIndex = 0,
                    Name = "MatchCode",
                    Value = totalText,
                    MergeColNumber = baseColumnIndex,
                    CellAlignment = HAlignment.Right
                }
            };

            var baseColumns = notDisplayHomeAwaySportTypeList.Contains(item.SportType) ? CreateBaseColumnsForNotDisplayHomeAway(baseColumnIndex, item)
                : CreateBaseColumns(baseColumnIndex, item);
            colummns.AddRange(baseColumns);

            return new GridDataRow { Columns = colummns };
        }

        private static List<Columns> CreateBaseColumns(int columnIndex, WinLoss item)
        {
            return new List<Columns>
            {
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.ExtraPT),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.Variance),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualMargin", item.ExcelVirtualMargin()),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };
        }

        private static List<Columns> CreateBaseColumnsForNotDisplayHomeAway(int columnIndex, WinLoss item)
        {
            return new List<Columns>
            {
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.ExtraPT),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };
        }
    }
}