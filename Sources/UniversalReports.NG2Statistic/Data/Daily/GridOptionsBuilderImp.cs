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
                FooterRows = BuildFooter(dailyModel.Total),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,                
            };
        }

        private List<GridDataRow> BuildBodyRows(DailyRaw dailyModel)
        {
            int index = 0;
            int indexGroup = 0;
            string cssClass = string.Empty;
            var gridRows = new List<GridDataRow>();
            foreach (var dates in dailyModel.Rows)
            {
                cssClass = indexGroup % 2 == 0 ? string.Empty : "parent-level-0";
                foreach (var date in dates.Rows)
                {
                    var gridRow = index == 0
                        ? BuildDataRowMergeColumn(date, dates.Rows.Count, cssClass)
                        : BuildDataRowAfterMerge(date, cssClass);
                    gridRows.Add(gridRow);

                    index++;
                }

                index = 0;
                indexGroup++;
            }

            return gridRows;
        }

        private List<GridDataRow> BuildFooter(DailyRaw total)
        {
            return new List<GridDataRow>() { BuildDataRow(total, string.Empty) };
        }

        private GridDataRow BuildDataRow(DailyRaw raw, string cssClass)
        {
            HAlignment mainTextAlignment = HAlignment.Center;
            var columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name, CellAlignment = mainTextAlignment },
                new Columns { ColumnIndex = columnIndex++, Name = "NoOfPlayers", Value = raw.NoOfPlayers },
                new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name },
                new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() },
                new Columns { ColumnIndex = columnIndex++, Name = "TotalBets", Value = raw.TotalBets },
                new Columns { ColumnIndex = columnIndex++, Name = "TotalWins", Value = raw.TotalWins },
                new Columns { ColumnIndex = columnIndex++, Name = "GameIncome", Value = raw.GameIncome },
                new Columns { ColumnIndex = columnIndex++, Name = "GamePayout", Value = raw.GamePayout },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyTurnover", Value = raw.CompanyTurnover },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyComm", Value = raw.CompanyComm },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyNetIncome", Value = raw.CompanyNetIncome }
            };

            return new GridDataRow { Columns = columns, CssClass = cssClass };
        }

        private GridDataRow BuildDataRowMergeColumn(DailyRaw raw, int mergeRowNumber, string cssClass)
        {
            HAlignment mainTextAlignment = HAlignment.Center;
            var columnIndex = 0;
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name, CellAlignment = mainTextAlignment, MergeRowNumber = mergeRowNumber },
                new Columns { ColumnIndex = columnIndex++, Name = "NoOfPlayers", Value = raw.NoOfPlayers },
                new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name },
                new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() },
                new Columns { ColumnIndex = columnIndex++, Name = "TotalBets", Value = raw.TotalBets },
                new Columns { ColumnIndex = columnIndex++, Name = "TotalWins", Value = raw.TotalWins },
                new Columns { ColumnIndex = columnIndex++, Name = "GameIncome", Value = raw.GameIncome },
                new Columns { ColumnIndex = columnIndex++, Name = "GamePayout", Value = raw.GamePayout },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyTurnover", Value = raw.CompanyTurnover },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyComm", Value = raw.CompanyComm },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyNetIncome", Value = raw.CompanyNetIncome }
            };

            return new GridDataRow { Columns = columns, CssClass = cssClass };
        }

        private GridDataRow BuildDataRowAfterMerge(DailyRaw raw, string cssClass)
        {
            var columnIndex = 1;
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "NoOfPlayers", Value = raw.NoOfPlayers },
                new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name },
                new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() },
                new Columns { ColumnIndex = columnIndex++, Name = "TotalBets", Value = raw.TotalBets },
                new Columns { ColumnIndex = columnIndex++, Name = "TotalWins", Value = raw.TotalWins },
                new Columns { ColumnIndex = columnIndex++, Name = "GameIncome", Value = raw.GameIncome },
                new Columns { ColumnIndex = columnIndex++, Name = "GamePayout", Value = raw.GamePayout },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyTurnover", Value = raw.CompanyTurnover },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyComm", Value = raw.CompanyComm },
                new Columns { ColumnIndex = columnIndex++, Name = "CompanyNetIncome", Value = raw.CompanyNetIncome }
            };

            return new GridDataRow { Columns = columns, CssClass = cssClass };
        }
    }
}