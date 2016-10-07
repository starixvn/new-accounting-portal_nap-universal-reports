using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

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
                new HeaderColumns { HeaderText = "No.PLayers", Width = 100, Name = "NoOfPlayers", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new HeaderColumns { HeaderText = "Bet Count", Width = 100, Name = "BetCount", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer },
                new HeaderColumns { HeaderText = "Currency", Width = 80, Name = "Currency", CellAlignment = HAlignment.Center },
                new HeaderColumns { HeaderText = "Total Bets", Width = 120, Name = "TotalBets", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Total Wins", Width = 120, Name = "TotalWins", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "Game Income", Width = 120, Name = "GameIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "Game Payout", Width = 120, Name = "GamePayout", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Percentage },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 150, Name = "CompanyTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double },
                new HeaderColumns { HeaderText = "Company Comm", Width = 130, Name = "CompanyComm", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative },
                new HeaderColumns { HeaderText = "Company Net Income", Width = 150, Name = "CompanyNetIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative }
            };
        }
    }
}