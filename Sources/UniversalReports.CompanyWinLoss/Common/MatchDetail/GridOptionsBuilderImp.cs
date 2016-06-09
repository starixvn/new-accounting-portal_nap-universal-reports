using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Extensions;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        public GridOptions Build(WinLossModel winloss, string title)
        {
            var gridOptions = new GridOptions
            {
                ShowTitle = true,
                TitleInfoText = title,
                TitleType = TitleType.OneLineBlue,
                BodyRows = BuildBodyRows(winloss.Leagues),
                FooterRows = BuildFooter(winloss),
                ShowFooter = true,
                ShowDistinctRow = false
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

            var leagueTotalRow = BuildTotalRow(league.Total, string.Empty);
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
                    MergeColNumber = 13,
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

        [SuppressMessage("StyleCop.CSharp.Nexcel.NexcelCustomRules",
            "SP2100:CodeLineMustNotBeLongerThan",
            Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuidMatchRow(WinLoss item, string leagueName)
        {
            var columnIndex = 0;
            var customAttributes = $"{item.SportType},{item.MatchId},'{item.EventDate:MMM dd, yyyy}','{leagueName}'";
            var colummns = new List<Columns>
            {
                new Columns(columnIndex++, "MatchCode", item.MatchCode)
                {
                    CustomAttributes = customAttributes,
                    Bold = true,
                    CssClass = "league-match-code",
                    CellAlignment = HAlignment.Center
                },
                new Columns(columnIndex++, "Home", item.HomeName),
                new Columns(columnIndex++, "VS", "-vs-") { CellAlignment = HAlignment.Center },
                new Columns(columnIndex++, "Away", item.AwayName) { CellAlignment = HAlignment.Left },
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualMargin", item.ExcelVirtualMargin()),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };

            return new GridDataRow { Columns = colummns, RowType = RowType.ParentLevelOne };
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
            var columnIndex = 4;
            var colummns = new List<Columns>
            {
                new Columns
                {
                    ColumnIndex = 0,
                    Name = "MatchCode",
                    Value = totalText,
                    MergeColNumber = 4,
                    CellAlignment = HAlignment.Right
                },
                new Columns(columnIndex++, "MemberWinLoss", item.MemberWinLoss),
                new Columns(columnIndex++, "SMAWinLoss", item.SMAWinLoss),
                new Columns(columnIndex++, "Commission", item.Commission),
                new Columns(columnIndex++, "VarianceIncome", item.VarianceIncome),
                new Columns(columnIndex++, "VirtualIncome", item.VirtualIncome),
                new Columns(columnIndex++, "RealIncome", item.RealIncome),
                new Columns(columnIndex++, "VirtualTurnover", item.VirtualTurnover),
                new Columns(columnIndex++, "RealTurnover", item.RealTurnover),
                new Columns(columnIndex++, "VirtualMargin", item.ExcelVirtualMargin()),
                new Columns(columnIndex, "RealMargin", item.ExcelRealMargin())
            };

            return new GridDataRow { Columns = colummns };
        }
    }
}