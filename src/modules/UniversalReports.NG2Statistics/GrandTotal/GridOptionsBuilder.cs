using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistics.GrandTotal
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(GrandTotalModel grandTotalModel, string title);
    }

    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        public GridOptions Build(GrandTotalModel grandTotalModel, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(grandTotalModel),
                FooterRows = BuildFooter(grandTotalModel.Total),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true
            };
        }

        private List<GridDataRow> BuildBodyRows(GrandTotalModel grandTotalModel)
        {
            return grandTotalModel.Rows.Select(s => BuildDataRow(s, false)).ToList();
        }

        private List<GridDataRow> BuildFooter(GrandTotalModel total)
        {
            return new List<GridDataRow> { BuildDataRow(total, true) };
        }

        private GridDataRow BuildDataRow(GrandTotalModel raw, bool isTotal)
        {
            var columns = new List<Columns>
            {
                new Columns { Name = "Name", Value = (isTotal ? "Grand Total " : "Total ") + raw.Currency, CellAlignment = HAlignment.Center },
                new Columns { Name = "NoOfPlayers", Value = raw.NoOfPlayers, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new Columns { Name = "BetCount", Value = raw.BetCount, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new Columns { Name = "Currency", Value = raw.Currency, CellAlignment = HAlignment.Center, CustomCellType = ExcelCellType.Integer },
                new Columns { Name = "TotalBets", Value = raw.TotalBets, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new Columns { Name = "TotalWins", Value = raw.TotalWins, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "GameIncome", Value = raw.GameIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "GamePayout", Value = raw.GamePayout, CellAlignment = HAlignment.Right, CustomCellType = raw.GamePayout > 1 ? ExcelCellType.PercentageRedPositive : ExcelCellType.Percentage, CssClass = raw.GamePayout > 1 ? "format-negative" : string.Empty },
                new Columns { Name = "HouseTurnover", Value = raw.HouseTurnover, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new Columns { Name = "HouseGrossIncome", Value = raw.HouseGrossIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseComm", Value = raw.HouseComm, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseNetIncome", Value = raw.HouseNetIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
            };
            return new GridDataRow { Columns = columns };
        }
    }
}