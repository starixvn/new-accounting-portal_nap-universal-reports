using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.NG2Statistic.GrandTotal
{
    public class GridOptionHeaderColumnImp : GridOptionHeaderColumn
    {
        public GridOptions Build(GridOptions gridOptions)
        {
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildColumns();
            gridOptions.GroupHeaderRows = new List<GroupHeaderRows>();

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
           "SP2100:CodeLineMustNotBeLongerThan",
           Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> BuildColumns()
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Grand Total", Width = 100, Name = "Name", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "No.PLayers", Width = 80, Name = "NoOfPlayers", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new HeaderColumns { HeaderText = "Bet Count", Width = 80, Name = "BetCount", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new HeaderColumns { HeaderText = "Currency", Width = 80, Name = "Currency", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "Total Bets", Width = 100, Name = "TotalBets", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Total Wins", Width = 100, Name = "TotalWins", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "Game Income", Width = 100, Name = "GameIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "Game Payout", Width = 100, Name = "GamePayout", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Percentage },
                new HeaderColumns { HeaderText = "House Turnover", Width = 120, Name = "HouseTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "House Gross Income", Width = 120, Name = "HouseGrossIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "House Comm", Width = 120, Name = "HouseComm", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "House Net Income", Width = 120, Name = "HouseNetIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative }
            };
        }
    }
}