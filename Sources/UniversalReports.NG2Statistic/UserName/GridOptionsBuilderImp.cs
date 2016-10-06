using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UniversalReports.NG2Statistic.UserName
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
            return new List<GridDataRow> { BuildDataRow(total, true) };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2100:CodeLineMustNotBeLongerThan", Justification = "Reviewed. Suppression is OK here.")]
        private GridDataRow BuildDataRow(UserNameModel raw, bool isTotal = false)
        {
            var columns = new List<Columns>
            {
                new Columns {Name = "Name", Value = raw.Name, CellAlignment = HAlignment.Center},
                new Columns
                {
                    Name = "CustId",
                    Value = isTotal ? string.Empty : raw.CustId.ToString(),
                    CellAlignment = HAlignment.Center
                },
                new Columns
                {
                    Name = "BetCount",
                    Value = raw.BetCount,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.Integer
                },
                new Columns {Name = "Currency", Value = raw.Currency, CellAlignment = HAlignment.Center},
                new Columns
                {
                    Name = "TotalBets",
                    Value = raw.TotalBets,
                    CellAlignment = HAlignment.Right,
                    CustomCellType = ExcelCellType.DoubleRedNegative
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
                    CustomCellType = ExcelCellType.DoubleRedNegative
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