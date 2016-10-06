using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.UserName
{
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
            return userNameModel.Rows.Select(s => BuildDataRow(s)).ToList();
        }

        private List<GridDataRow> BuildFooter(UserNameModel total)
        {
            return new List<GridDataRow>() { BuildDataRow(total, true) };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuildDataRow(UserNameModel raw, bool isTotal = false)
        {
            var columns = new List<Columns>();
            columns.Add(new Columns { Name = "Name", Value = raw.Name, CellAlignment = HAlignment.Center });
            if (isTotal)
            {
                columns.Add(new Columns { Name = "CustId", Value = string.Empty, CellAlignment = HAlignment.Center });
            }
            else
            {
                columns.Add(new Columns { Name = "CustId", Value = raw.CustId, CellAlignment = HAlignment.Center });
            }

            columns.Add(new Columns { Name = "BetCount", Value = raw.BetCount, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.Integer });
            columns.Add(new Columns { Name = "Currency", Value = raw.Currency, CellAlignment = HAlignment.Center });
            columns.Add(new Columns { Name = "TotalBets", Value = raw.TotalBets, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative });
            columns.Add(new Columns { Name = "TotalWins", Value = raw.TotalWins, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative });
            columns.Add(new Columns { Name = "GameIncome", Value = raw.GameIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative });
            columns.Add(new Columns { Name = "GamePayout", Value = raw.GamePayout, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.PercentageRedNegative });
            columns.Add(new Columns { Name = "CompanyTurnover", Value = raw.CompanyTurnover, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative });
            columns.Add(new Columns { Name = "CompanyComm", Value = raw.CompanyComm, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative });
            columns.Add(new Columns { Name = "CompanyNetIncome", Value = raw.CompanyNetIncome, CellAlignment = HAlignment.Right, CustomCellType = ExcelCellType.DoubleRedNegative });

            return new GridDataRow { Columns = columns };
        }
    }
}