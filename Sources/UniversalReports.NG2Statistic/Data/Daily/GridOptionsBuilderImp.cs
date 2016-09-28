using System.Collections.Generic;
using System.Linq;
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
                FooterRows = BuildFooter(dailyModel),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,
                ShowTree = true
            };
        }

        private List<GridDataRow> BuildBodyRows(DailyModel dailyModel)
        {
            return dailyModel
                .Rows
                .Select(BuildDataRow)
                .ToList();
        }

        private List<GridDataRow> BuildFooter(DailyModel dailyModel)
        {
            return dailyModel
                .GrandTotal
                .Select(BuildDataRow)
                .ToList();
        }

        private GridDataRow BuildDataRow(DailyRaw raw)
        {
            HAlignment mainTextAlignment = HAlignment.Center;
            var columnIndex = 0;            
            var columns = new List<Columns>
            {
                new Columns { ColumnIndex = columnIndex++, Name = "Name", Value = raw.Name, CustomAttributes = raw.Name, CellAlignment = mainTextAlignment },
                new Columns(columnIndex++, "NoOfPlayers", raw.NoOfPlayers),
                new Columns(columnIndex++, "BetCount", raw.BetCount),
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