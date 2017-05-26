using Fanex.Common;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.NG2Statistics.Daily
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(DailyModel dailyModel, string title);
    }

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
                ShowFooter = true
            };
        }

        private List<GridDataRow> BuildBodyRows(DailyModel dailyModel)
        {
            var index = 0;
            var indexGroup = 0;
            var gridRows = new List<GridDataRow>();
            foreach (var dates in dailyModel.Rows)
            {
                var cssClass = indexGroup % 2 == 0 ? string.Empty : "parent-level-0";
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
            return new List<GridDataRow> { BuildDataTotalRow(total) };
        }

        private GridDataRow BuildDataRow(DailyModel raw, int mergeRowNumber, string cssClass)
        {
            var columns = new List<Columns>();
            if (mergeRowNumber > 0)
            {
                columns.Add(new Columns { Name = "Winlostdate", Value = Converter.To<DateTime>(raw.Winlostdate).ToString("MMM dd, yyyy"), MergeRowNumber = mergeRowNumber });
            }

            AssignDataRow(raw, columns);

            return new GridDataRow
            {
                Columns = columns,
                CssClass = cssClass,
                RowType = string.IsNullOrEmpty(cssClass) ? RowType.Normal : RowType.Even
            };
        }

        private GridDataRow BuildDataTotalRow(DailyModel raw)
        {
            var columns = new List<Columns> { new Columns { Name = "Winlostdate", Value = raw.Name } };

            AssignDataRow(raw, columns);

            return new GridDataRow { Columns = columns };
        }

        private void AssignDataRow(DailyModel raw, List<Columns> columns)
        {
            var newColumns = new List<Columns>
            {
                new Columns { Name = "NoOfPlayers", Value = raw.NoOfPlayers, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new Columns { Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.Winlostdate.ToShortDateString(), CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new Columns { Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString(), CellAlignment = HAlignment.Center },
                new Columns { Name = "TotalBets", Value = raw.TotalBets, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new Columns { Name = "TotalWins", Value = raw.TotalWins, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new Columns { Name = "GameIncome", Value = raw.GameIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "GamePayout", Value = raw.GamePayout, CellAlignment = HAlignment.Right, CustomCellType = raw.GamePayout > 1 ? ExcelCellType.PercentageRedPositive : ExcelCellType.Percentage, CssClass = raw.GamePayout > 1 ? "format-negative" : string.Empty },
                new Columns { Name = "HouseTurnover", Value = raw.HouseTurnover, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseGrossIncome", Value = raw.HouseGrossIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseComm", Value = raw.HouseComm, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseNetIncome", Value = raw.HouseNetIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative }
            };

            columns.AddRange(newColumns);
        }
    }
}