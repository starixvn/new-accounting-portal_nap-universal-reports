using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data
{
    public class GridOptionHeaderColumnImp : GridOptionHeaderColumn
    {
        public GridOptions Build(GridOptions gridOptions, string mainColumnText, int mainColumnWidth = 180)
        {
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildColumns(mainColumnText, mainColumnWidth);
            gridOptions.GroupHeaderRows = new List<GroupHeaderRows>();            

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
           "SP2100:CodeLineMustNotBeLongerThan",
           Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> BuildColumns(string mainColumnText, int mainColumnWidth = 180)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Width = mainColumnWidth, Name = "Name", CellAlignment = HAlignment.Center, Sort = true, SortType = "string" },
                new HeaderColumns { HeaderText = "No.PLayers", Width = 100, Name = "NoOfPlayers", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Bet Count", Width = 100, Name = "BetCount", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Currency", Width = 100, Name = "Currency", CellAlignment = HAlignment.Center, Sort = true, SortType = "string" },
                new HeaderColumns { HeaderText = "Total Bets", Width = 100, Name = "TotalBets", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Total Wins", Width = 100, Name = "TotalWins", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Game Income", Width = 100, Name = "GameIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Game Payout", Width = 100, Name = "GamePayout", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Percentage, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 150, Name = "CompanyTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Company Comm", Width = 130, Name = "CompanyComm", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortType = "number" },
                new HeaderColumns { HeaderText = "Company Net Income", Width = 150, Name = "CompanyNetIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortType = "number" }                
            };
        }
    }
}
