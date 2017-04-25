using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.NG2Statistics.UserName
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(UserNameModel userNameModel, string title);
    }

    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        public GridOptions Build(UserNameModel userNameModel, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(userNameModel),
                FooterRows = BuildFooter(userNameModel.Total),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true,
                ShowPager = true
            };
        }

        private List<GridDataRow> BuildBodyRows(UserNameModel userNameModel)
        {
            var gridRows = new List<GridDataRow>();
            var index = 0;
            foreach (var user in userNameModel.Rows)
            {
                var cssClass = index % 2 == 0 ? "parent-level-0" : string.Empty;
                var rowType = index % 2 == 0 ? RowType.Even : RowType.Normal;
                var gridRow = BuildDataRow(user, false, cssClass, rowType);
                gridRows.Add(gridRow);
                index++;
            }

            return gridRows;
        }

        private List<GridDataRow> BuildFooter(UserNameModel total)
        {
            return new List<GridDataRow> { BuildDataRow(total, true, string.Empty, RowType.Normal) };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuildDataRow(UserNameModel raw, bool isTotal, string cssClass, RowType rowType)
        {
            object custId = raw.CustId;
            if (isTotal)
            {
                custId = string.Empty;
            }

            var columns = new List<Columns>
            {
                new Columns { Name = "Username", Value = raw.Username, CellAlignment = HAlignment.Center },
                new Columns { Name = "CustId", Value = custId, CellAlignment = HAlignment.Center },
                new Columns { Name = "BetCount", Value = raw.BetCount, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new Columns { Name = "Currency", Value = raw.Currency, CellAlignment = HAlignment.Center },
                new Columns { Name = "TotalBets", Value = raw.TotalBets, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "TotalWins", Value = raw.TotalWins, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "GameIncome", Value = raw.GameIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "GamePayout", Value = raw.GamePayout, CellAlignment = HAlignment.Right, CustomCellType = raw.GamePayout > 1 ? ExcelCellType.PercentageRedPositive : ExcelCellType.Percentage, CssClass = raw.GamePayout > 1 ? "format-negative" : string.Empty },
                new Columns { Name = "HouseTurnover", Value = raw.HouseTurnover, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseGrossIncome", Value = raw.HouseGrossIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseComm", Value = raw.HouseComm, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new Columns { Name = "HouseNetIncome", Value = raw.HouseNetIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative }
            };

            return new GridDataRow { Columns = columns, CssClass = cssClass, RowType = rowType };
        }
    }
}