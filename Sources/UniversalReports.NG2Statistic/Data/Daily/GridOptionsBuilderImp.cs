using System.Collections.Generic;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        public GridOptions Build(DailyModel dailyModel, string title)
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

        private List<GridDataRow> BuildBodyRows(DailyModel dailyModel)
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

        private List<GridDataRow> BuildFooter(DailyModel total)
        {
            return new List<GridDataRow>() { BuildDataTotalRow(total) };
        }

        private GridDataRow BuildDataRow(DailyModel raw, int mergeRowNumber, string cssClass)
        {
            var columns = new List<Columns>();
            if (mergeRowNumber > 0)
            {
                columns.Add(new Columns { Name = "Name", Value = raw.Name, MergeRowNumber = mergeRowNumber });
            }

            AssignDataRow(raw, columns);

            return new GridDataRow { Columns = columns, CssClass = cssClass, RowType = string.IsNullOrEmpty(cssClass) ? RowType.Normal : RowType.Even };
        }

        private GridDataRow BuildDataTotalRow(DailyModel raw)
        {
            var columns = new List<Columns>();
            columns.Add(new Columns { Name = "Name", Value = raw.Name });

            AssignDataRow(raw, columns);

            return new GridDataRow { Columns = columns };
        }

        private void AssignDataRow(DailyModel raw, List<Columns> columns)
        {
            columns.Add(new Columns { Name = "NoOfPlayers", Value = raw.NoOfPlayers });
            columns.Add(new Columns { Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Name });
            columns.Add(new Columns { Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() });
            columns.Add(new Columns { Name = "TotalBets", Value = raw.TotalBets });
            columns.Add(new Columns { Name = "TotalWins", Value = raw.TotalWins });
            columns.Add(new Columns { Name = "GameIncome", Value = raw.GameIncome });
            columns.Add(new Columns { Name = "GamePayout", Value = raw.GamePayout });
            columns.Add(new Columns { Name = "CompanyTurnover", Value = raw.CompanyTurnover });
            columns.Add(new Columns { Name = "CompanyComm", Value = raw.CompanyComm });
            columns.Add(new Columns { Name = "CompanyNetIncome", Value = raw.CompanyNetIncome });
        }
    }
}