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
                    var mergeRowNumber = index == 0 ? dates.Rows.Count : 0;
                    var gridRow = BuildDataRow(date, mergeRowNumber, cssClass);
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
            return new List<GridDataRow>() { BuildDataTotalRow(total) };
        }

        private GridDataRow BuildDataRow(DailyRaw raw, int mergeRowNumber, string cssClass)
        {
            var columns = new List<Columns>();
            var columnIndex = 0;
            if (mergeRowNumber > 1)
            {
                columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name, MergeRowNumber = mergeRowNumber });
            }
            else
            {
                columnIndex = 1;
            }

            AssignDataRow(raw, columns, columnIndex);

            return new GridDataRow { Columns = columns, CssClass = cssClass }; ;
        }

        private GridDataRow BuildDataTotalRow(DailyRaw raw)
        {
            var columns = new List<Columns>();
            var columnIndex = 0;
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name });

            AssignDataRow(raw, columns, columnIndex);

            return new GridDataRow { Columns = columns };
        }

        private void AssignDataRow(DailyRaw raw, List<Columns> columns, int columnIndex)
        {
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "NoOfPlayers", Value = raw.NoOfPlayers });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "TotalBets", Value = raw.TotalBets });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "TotalWins", Value = raw.TotalWins });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "GameIncome", Value = raw.GameIncome });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "GamePayout", Value = raw.GamePayout });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "CompanyTurnover", Value = raw.CompanyTurnover });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "CompanyComm", Value = raw.CompanyComm });
            columns.Add(new Columns { ColumnIndex = columnIndex++, Name = "CompanyNetIncome", Value = raw.CompanyNetIncome });            
        }       
    }
}