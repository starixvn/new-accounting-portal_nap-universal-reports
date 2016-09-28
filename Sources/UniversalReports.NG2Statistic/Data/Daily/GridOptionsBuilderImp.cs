using System.Collections.Generic;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        public GridOptions Build(DailyRaw dailyModel, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(dailyModel),
                FooterRows = BuildFooter(dailyModel),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,
                ShowTree = true
            };
        }

        private List<GridDataRow> BuildBodyRows(DailyRaw dailyModel)
        {
            //return dailyModel
            //    .Rows
            //    .Select(BuildDataRow)
            //    .ToList();
            int index = 0;
            var gridRows = new List<GridDataRow>();
            foreach (var dates in dailyModel.Rows)
            {
                foreach (var date in dates.Rows)
                {
                    var gridRow = index == 0
                        ? BuildDataRowMergeColumn(date, dates.Rows.Count)
                        : BuildDataRowAfterMerge(date);
                    gridRows.Add(gridRow);

                    index++;
                }

                index = 0;
            }

            return gridRows;
        }

        private List<GridDataRow> BuildFooter(DailyRaw dailyModel)
        {
            return new List<GridDataRow>() { BuildDataRow(dailyModel.Total) };
        }

        private GridDataRow BuildDataRow(DailyRaw raw)
        {
            HAlignment mainTextAlignment = HAlignment.Center;
            var columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name, CellAlignment = mainTextAlignment },
                new Columns(columnIndex++, "NoOfPlayers", raw.NoOfPlayers),
                new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name },
                new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() },
                new Columns(columnIndex++, "TotalBets", raw.TotalBets),
                new Columns(columnIndex++, "TotalWins", raw.TotalWins),
                new Columns(columnIndex++, "GameIncome", raw.GameIncome),
                new Columns(columnIndex++, "GamePayout", raw.GamePayout),
                new Columns(columnIndex++, "CompanyTurnover", raw.CompanyTurnover),
                new Columns(columnIndex++, "CompanyComm", raw.CompanyComm),
                new Columns(columnIndex++, "CompanyNetIncome", raw.CompanyNetIncome)
            };

            return new GridDataRow { Columns = columns };
        }

        private GridDataRow BuildDataRowMergeColumn(DailyRaw raw, int mergeRowNumber)
        {
            HAlignment mainTextAlignment = HAlignment.Center;
            var columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name, CellAlignment = mainTextAlignment, MergeRowNumber = mergeRowNumber },
                new Columns(columnIndex++, "NoOfPlayers", raw.NoOfPlayers),
                new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name },
                new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() },
                new Columns(columnIndex++, "TotalBets", raw.TotalBets),
                new Columns(columnIndex++, "TotalWins", raw.TotalWins),
                new Columns(columnIndex++, "GameIncome", raw.GameIncome),
                new Columns(columnIndex++, "GamePayout", raw.GamePayout),
                new Columns(columnIndex++, "CompanyTurnover", raw.CompanyTurnover),
                new Columns(columnIndex++, "CompanyComm", raw.CompanyComm),
                new Columns(columnIndex++, "CompanyNetIncome", raw.CompanyNetIncome)
            };

            return new GridDataRow { Columns = columns };
        }

        private GridDataRow BuildDataRowAfterMerge(DailyRaw raw)
        {
            var columnIndex = 1;
            var columns = new List<Columns>
            {
                new Columns(columnIndex++, "NoOfPlayers", raw.NoOfPlayers),
                new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name },
                new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() },
                new Columns(columnIndex++, "TotalBets", raw.TotalBets),
                new Columns(columnIndex++, "TotalWins", raw.TotalWins),
                new Columns(columnIndex++, "GameIncome", raw.GameIncome),
                new Columns(columnIndex++, "GamePayout", raw.GamePayout),
                new Columns(columnIndex++, "CompanyTurnover", raw.CompanyTurnover),
                new Columns(columnIndex++, "CompanyComm", raw.CompanyComm),
                new Columns(columnIndex++, "CompanyNetIncome", raw.CompanyNetIncome)
            };

            return new GridDataRow { Columns = columns };
        }
    }
}