using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        public GridOptions Build(BettypeModel bettypeModel, string title)
        {
            return new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = title,
                BodyRows = BuildBodyRows(bettypeModel),
                FooterRows = BuildFooter(bettypeModel.Total),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true
            };
        }

        private List<GridDataRow> BuildBodyRows(BettypeModel bettypeModel)
        {
            var index = 0;
            var indexGroup = 0;
            var gridRows = new List<GridDataRow>();
            foreach (var sportType in bettypeModel.Rows)
            {
                var cssClass = indexGroup % 2 == 0 ? string.Empty : "parent-level-0";
                foreach (var bettype in sportType.Rows)
                {
                    var gridRow = BuildDataRow(bettype, cssClass, index == 0, indexGroup);
                    gridRows.Add(gridRow);

                    index++;
                }

                index = 0;
                indexGroup++;
            }

            return gridRows;
        }

        private List<GridDataRow> BuildFooter(BettypeModel total)
        {
            return new List<GridDataRow> { BuildDataTotalRow(total) };
        }

        private GridDataRow BuildDataRow(BettypeModel raw, string cssClass, bool isSport, int indexGroup)
        {
            var columns = new List<Columns>();
            AssignDataRow(raw, columns, isSport);
            if (isSport)
            {
                cssClass = cssClass + " ng2-sport-bold";
            }

            return new GridDataRow
            {
                Columns = columns,
                CssClass = cssClass,
                RowType = indexGroup % 2 == 0 ? RowType.Normal : RowType.Even
            };
        }

        private GridDataRow BuildDataTotalRow(BettypeModel raw)
        {
            var columns = new List<Columns>();
            AssignDataRow(raw, columns, true);

            return new GridDataRow { Columns = columns };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]

        private void AssignDataRow(BettypeModel raw, ICollection<Columns> columns, bool isSport)
        {
            var bold = isSport;
            if (isSport)
            {
                columns.Add(new Columns { Name = "Name", Value = raw.Sporttype, Bold = true, CellAlignment = HAlignment.Left });
            }
            else
            {
                columns.Add(new Columns
                {
                    Name = "Name",
                    Value = raw.Bettype,
                    Bold = false,
                    CellAlignment = HAlignment.Right
                });
            }

            columns.Add(new Columns
            {
                Name = "NoOfPlayers",
                Value = raw.NoOfPlayers,
                Bold = bold,
                CustomAttributes = raw.SportId.ToString(),
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.Integer
            });
            columns.Add(new Columns
            {
                Name = "BetCount",
                Value = raw.BetCount,
                Bold = bold,
                CustomAttributes = raw.BettypeId.ToString(),
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.Integer
            });
            columns.Add(new Columns
            {
                Name = "Currency",
                Value = raw.Currency,
                Bold = bold,
                CustomAttributes = raw.CurrencyId.ToString(),
                CellAlignment = HAlignment.Center
            });
            columns.Add(new Columns
            {
                Name = "TotalBets",
                Value = raw.TotalBets,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "TotalWins",
                Value = raw.TotalWins,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "GameIncome",
                Value = raw.GameIncome,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "GamePayout",
                Value = raw.GamePayout,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.PercentageRedNegative
            });
            columns.Add(new Columns
            {
                Name = "CompanyTurnover",
                Value = raw.CompanyTurnover,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "CompanyComm",
                Value = raw.CompanyComm,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "CompanyNetIncome",
                Value = raw.CompanyNetIncome,
                Bold = bold,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
        }
    }
}