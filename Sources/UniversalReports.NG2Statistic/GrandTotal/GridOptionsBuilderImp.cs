using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.GrandTotal
{
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
            return grandTotalModel.Rows.Select(BuildDataRow).ToList();
        }

        private List<GridDataRow> BuildFooter(GrandTotalModel total)
        {
            return new List<GridDataRow> { BuildDataRow(total) };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuildDataRow(GrandTotalModel raw)
        {
            var columns = new List<Columns>
            {
                new Columns { Name = "Name", Value = raw.Currency, CellAlignment = HAlignment.Center },
                new Columns
                {
                    Name = "NoOfPlayers",
                    Value = raw.NoOfPlayers,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.Integer
                },
                new Columns
                {
                    Name = "BetCount",
                    Value = raw.BetCount,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.Integer
                },
                new Columns
                {
                    Name = "Currency",
                    Value = raw.Currency,
                    CellAlignment = HAlignment.Center,
                    CustomCellType = ExcelCellType.Integer
                },
                new Columns
                {
                    Name = "TotalBets",
                    Value = raw.TotalBets,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.Double
                },
                new Columns
                {
                    Name = "TotalWins",
                    Value = raw.TotalWins,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.DoubleRedNegative
                },
                new Columns
                {
                    Name = "GameIncome",
                    Value = raw.GameIncome,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.DoubleRedNegative
                },
                new Columns
                {
                    Name = "GamePayout",
                    Value = raw.GamePayout,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.PercentageRedNegative
                },
                new Columns
                {
                    Name = "CompanyTurnover",
                    Value = raw.CompanyTurnover,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.Double
                },
                new Columns
                {
                    Name = "CompanyComm",
                    Value = raw.CompanyComm,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.DoubleRedNegative
                },
                new Columns
                {
                    Name = "CompanyNetIncome",
                    Value = raw.CompanyNetIncome,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.DoubleRedNegative
                }
            };

            return new GridDataRow { Columns = columns };
        }
    }
}