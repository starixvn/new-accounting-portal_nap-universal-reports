using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.UserName
{
    public class GridOptionHeaderColumnImp : GridOptionHeaderColumn
    {
        public GridOptions Build(GridOptions gridOptions, QueryModel queryModel)
        {
            gridOptions.CustomizeHeader = true;
            gridOptions.Columns = BuildColumns(queryModel);
            gridOptions.GroupHeaderRows = new List<GroupHeaderRows>();            

            return gridOptions;
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
           "SP2100:CodeLineMustNotBeLongerThan",
           Justification = "Reviewed. Suppression is OK here.")]
        protected List<HeaderColumns> BuildColumns(QueryModel queryModel)
        {
            return new List<HeaderColumns>
            {
                new HeaderColumns { HeaderText = "Username", Width = 130, Name = "Name", CellAlignment = HAlignment.Center, Sort = true, SortDirection = queryModel.SortColumnName == "Name" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Player ID", Width = 100, Name = "CustId", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.General, Sort = true, SortDirection = queryModel.SortColumnName == "CustId" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Bet Count", Width = 100, Name = "BetCount", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer, Sort = true, SortDirection = queryModel.SortColumnName == "BetCount" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Currency", Width = 80, Name = "Currency", CellAlignment = HAlignment.Center, Sort = true, SortDirection = queryModel.SortColumnName == "Currency" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Total Bets", Width = 120, Name = "TotalBets", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double, Sort = true, SortDirection = queryModel.SortColumnName == "TotalBets" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Total Wins", Width = 120, Name = "TotalWins", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "TotalWins" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Game Income", Width = 120, Name = "GameIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "GameIncome" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Game Payout", Width = 120, Name = "GamePayout", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Percentage, Sort = true, SortDirection = queryModel.SortColumnName == "GamePayout" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Company Turnover", Width = 150, Name = "CompanyTurnover", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Double, Sort = true, SortDirection = queryModel.SortColumnName == "CompanyTurnover" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Company Comm", Width = 130, Name = "CompanyComm", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "CompanyComm" ? queryModel.SortDirection : string.Empty },
                new HeaderColumns { HeaderText = "Company Net Income", Width = 150, Name = "CompanyNetIncome", CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative, Sort = true, SortDirection = queryModel.SortColumnName == "CompanyNetIncome" ? queryModel.SortDirection : string.Empty }
            };
        }
    }
}