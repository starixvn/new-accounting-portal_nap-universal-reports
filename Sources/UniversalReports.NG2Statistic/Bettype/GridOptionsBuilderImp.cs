using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
            var gridRows = new List<GridDataRow>();
            int currentBettypeId = 0;
            int preBettypeId = 0;
            int mergeRowNumber = 0;
            foreach (var sportType in bettypeModel.Rows)
            {
                foreach (var bettype in sportType.Rows)
                {
                    currentBettypeId = bettype.BettypeId;
                    if (currentBettypeId != preBettypeId)
                    {
                        preBettypeId = currentBettypeId;
                        mergeRowNumber = sportType.Rows.Count(s => s.BettypeId == currentBettypeId);
                    }
                    else
                    {
                        mergeRowNumber = currentBettypeId == 0 ? 1 : 0;
                    }

                    var cssClass = index == 0 ? "parent-level-0" : string.Empty;
                    if (index == 0)
                    {
                        var sportTypeRow = BuildDataSportRow(sportType.Sporttype);
                        gridRows.Add(sportTypeRow);
                    }

                    var bettypeRow = BuildDataRow(bettype, mergeRowNumber, false);
                    gridRows.Add(bettypeRow);

                    index++;
                }

                index = 0;
            }

            return gridRows;
        }

        private GridDataRow BuildDataSportRow(string sportType)
        {
            var columns = new List<Columns>();
            columns.Add(new Columns { Name = "Bettype", Value = sportType, Bold = true, CellAlignment = HAlignment.Left, MergeColNumber = 11 });

            return new GridDataRow { Columns = columns, RowType = RowType.Even, CssClass = "parent-level-0 ng2-sport-bold" };
        }

        private List<GridDataRow> BuildFooter(BettypeModel total)
        {
            return new List<GridDataRow> { BuildDataTotalRow(total) };
        }

        private GridDataRow BuildDataRow(BettypeModel raw, int mergeRowNumber, bool isTotal)
        {
            var columns = new List<Columns>();
            AssignDataRow(raw, columns, mergeRowNumber, isTotal);

            return new GridDataRow
            {
                Columns = columns
            };
        }

        private GridDataRow BuildDataTotalRow(BettypeModel raw)
        {
            var columns = new List<Columns>();
            AssignDataRow(raw, columns, 1, true);

            return new GridDataRow { Columns = columns };
        }

        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules", "SP2101:MethodMustNotContainMoreLinesThan", Justification = "Reviewed. Suppression is OK here.")]
        private void AssignDataRow(BettypeModel raw, ICollection<Columns> columns, int mergeRowNumber, bool isTotal)
        {
            if (mergeRowNumber > 0 || isTotal)
            {
                columns.Add(new Columns
                {
                    Name = "Bettype",
                    Value = raw.Bettype,
                    CellAlignment = isTotal ? HAlignment.Center : HAlignment.Right,
                    MergeRowNumber = mergeRowNumber
                });
            }

            columns.Add(new Columns
            {
                Name = "NoOfPlayers",
                Value = raw.NoOfPlayers,
                CustomAttributes = raw.SportId.ToString(),
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.Integer
            });
            columns.Add(new Columns
            {
                Name = "BetCount",
                Value = raw.BetCount,
                CustomAttributes = raw.BettypeId.ToString(),
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.Integer
            });
            columns.Add(new Columns
            {
                Name = "Currency",
                Value = raw.Currency,
                CustomAttributes = raw.CurrencyId.ToString(),
                CellAlignment = HAlignment.Center
            });
            columns.Add(new Columns
            {
                Name = "TotalBets",
                Value = raw.TotalBets,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "TotalWins",
                Value = raw.TotalWins,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "GameIncome",
                Value = raw.GameIncome,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "GamePayout",
                Value = raw.GamePayout,
                CellAlignment = HAlignment.Right,
                CustomCellType = raw.GamePayout > 1 ? ExcelCellType.PercentageRedPositive : ExcelCellType.Percentage,
                CssClass = raw.GamePayout > 1 ? "format-negative" : string.Empty
            });
            columns.Add(new Columns
            {
                Name = "CompanyTurnover",
                Value = raw.CompanyTurnover,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "CompanyComm",
                Value = raw.CompanyComm,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "CompanyNetIncome",
                Value = raw.CompanyNetIncome,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
        }
    }
}