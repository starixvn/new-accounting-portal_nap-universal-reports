using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Extensions;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public class MatchDetailGridOptionServiceImp : MatchDetailGridOptionService
    {
        public GridOptions FromWinLossModel(WinLossModel winloss, string title)
        {
            return new GridOptions
            {
                ShowTitle = true,
                TitleInfoText = title,
                TitleType = TitleType.TwoLineBlue,
                BodyRows = BuildBodyRows(winloss.Leagues),
                FooterRows = BuildFooter(winloss),
                ShowFooter = true
            };
        }

        private List<GridDataRow> BuildBodyRows(List<LeagueWinLoss> leagueWinLoss)
        {
            var gridDataRows = leagueWinLoss.Select(BuildLeagueDataRows).ToList();

            return gridDataRows.SelectMany(x => x).ToList();
        }

        private List<GridDataRow> BuildLeagueDataRows(LeagueWinLoss league)
        {
            var dataRows = new List<GridDataRow>();
            var leagueNameRow = BuildLeagueNameRow(league.LeagueName);
            var matchRows = league.Matches.Select(BuidMatchRow);

            dataRows.Add(leagueNameRow);
            dataRows.AddRange(matchRows);

            if (league.Matches.Count > 1)
            {
                var leagueTotalRow = BuildTotalRow(league.Total, string.Empty);
                dataRows.Add(leagueTotalRow);
            }

            return dataRows;
        }

        private GridDataRow BuildLeagueNameRow(string leagueName)
        {
            int columnIndex = 0;
            var colummns = new List<Columns>
               {
                    new Columns { ColumnIndex = columnIndex++, Name = "MatchCode", Value = string.Empty },
                    new Columns { ColumnIndex = columnIndex, Name = "MemberWinLoss", Value = leagueName, MergeColNumber = 13, Bold = true, CellAlignment = HAlignment.Left }
               };

            return new GridDataRow { Columns = colummns };
        }

        private GridDataRow BuidMatchRow(MatchDetailWinLoss item)
        {
            int columnIndex = 0;
            var colummns = new List<Columns>
            {
                new Columns(columnIndex++, "MatchCode", item.MatchCode),
                new Columns(columnIndex++, "Home", item.HomeName),
                new Columns(columnIndex++, "VS", "-vs-"),
                new Columns(columnIndex++, "Away", item.AwayName),
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

        private List<GridDataRow> BuildFooter(WinLossModel model)
        {
            var totalRow = BuildTotalRow(model.Total, "Grand Total");
            var allRMRows = model.RM.Select(r => BuildTotalRow(r, r.MatchCode));

            var result = new List<GridDataRow> { totalRow };
            result.AddRange(allRMRows);

            return result;
        }

        private GridDataRow BuildTotalRow(MatchDetailWinLoss item, string totalText)
        {
            int startColumnIndex = 0;
            int columnIndex = 4;
            var colummns = new List<Columns>
            {
                new Columns { ColumnIndex = startColumnIndex, Name = "MatchCode", Value = totalText, MergeColNumber = 4, CellAlignment = HAlignment.Right },
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