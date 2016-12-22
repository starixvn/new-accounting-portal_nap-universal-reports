using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace UniversalReports.NG2Statistic.BaseServices
{
    public class BaseGridOptionHeaderColumnImp : BaseGridOptionHeaderColumn
    {
        public GridOptions Build(GridOptions gridOptions, string mainColumnText, string mainColumnName, QueryModel queryModel)
        {
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildColumns(mainColumnText, mainColumnName, queryModel);
            gridOptions.GroupHeaderRows = new List<GroupHeaderRows>();

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
           "SP2100:CodeLineMustNotBeLongerThan",
           Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> BuildColumns(string mainColumnText, string mainColumnName, QueryModel queryModel)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = mainColumnText, Width = 100, Name = mainColumnName, CellAlignment = HAlignment.Center, Sort = true, SortDirection = queryModel.SortColumnName == mainColumnName ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "No.PLayers", Width = 100, Name = "NoOfPlayers", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer, Sort = true, SortDirection = queryModel.SortColumnName == "NoOfPlayers" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Bet Count", Width = 100, Name = "BetCount", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer, Sort = true, SortDirection = queryModel.SortColumnName == "BetCount" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Currency", Width = 100, Name = "Currency", CellAlignment = HAlignment.Center, Sort = true, SortDirection = queryModel.SortColumnName == "Currency" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Total Bets", Width = 120, Name = "TotalBets", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double, Sort = true, SortDirection = queryModel.SortColumnName == "TotalBets" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Total Wins", Width = 120, Name = "TotalWins", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "TotalWins" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Game Income", Width = 120, Name = "GameIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "GameIncome" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Game Payout", Width = 120, Name = "GamePayout", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Percentage, Sort = true, SortDirection = queryModel.SortColumnName == "GamePayout" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "House Turnover", Width = 150, Name = "HouseTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double, Sort = true, SortDirection = queryModel.SortColumnName == "HouseTurnover" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "House Gross Income", Width = 150, Name = "HouseGrossIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "HouseGrossIncome" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "House Comm", Width = 130, Name = "HouseComm", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "HouseComm" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "House Net Income", Width = 150, Name = "HouseNetIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "HouseNetIncome" ? queryModel.SortDirection : string.Empty }
            };
        }
    }
}