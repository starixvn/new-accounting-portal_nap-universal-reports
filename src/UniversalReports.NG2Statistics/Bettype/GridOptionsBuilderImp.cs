using Fanex.Excel.Enums;
using Fanex.Excel.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public interface GridOptionsBuilder
    {
        GridOptions Build(BettypeModel bettypeModel, QueryModel queryModel);
    }

    public class GridOptionsBuilderImp : GridOptionsBuilder
    {
        private readonly BaseGridOptionHeaderColumn headerBuilder;

        public GridOptionsBuilderImp(BaseGridOptionHeaderColumn headerBuilder)
        {
            this.headerBuilder = headerBuilder;
        }

        public GridOptions Build(BettypeModel bettypeModel, QueryModel queryModel)
        {
            var gridOptions = new GridOptions
            {
                CustomizeHeader = true,
                ShowTitle = true,
                TitleType = TitleType.TwoLineBlue,
                TitleInfoText = queryModel.Title,
                BodyRows = BuildBodyRows(bettypeModel),
                FooterRows = BuildFooter(bettypeModel.Total),
                ShowHighlightRow = false,
                ShowDistinctRow = false,
                ShowFooter = true
            };

            return headerBuilder.Build(gridOptions, "Bet Type", "Bettype", queryModel);
        }

        private List<GridDataRow> BuildBodyRows(BettypeModel bettypeModel)
        {
            var bettypeIndex = 0;
            var gridRows = new List<GridDataRow>();
            foreach (var sportType in bettypeModel.Rows)
            {
                var sportTypeRow = BuildDataSportRow(sportType.Sporttype);
                gridRows.Add(sportTypeRow);

                foreach (var bettype in sportType.Rows)
                {
                    var mergeRowNumber = bettype.Rows.Count;
                    foreach (var row in bettype.Rows)
                    {
                        if (bettypeIndex > 0)
                        {
                            mergeRowNumber = 0;
                        }

                        var bettypeRow = BuildDataRow(row, mergeRowNumber, false);
                        gridRows.Add(bettypeRow);

                        bettypeIndex++;
                    }

                    bettypeIndex = 0;
                }
            }

            return gridRows;
        }

        private GridDataRow BuildDataSportRow(string sportType)
        {
            var columns = new List<Columns>
            {
                new Columns
                {
                    Name = "Bettype",
                    Value = sportType,
                    Bold = true,
                    CellAlignment = HAlignment.Left,
                    MergeColNumber = 12
                }
            };

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
                Name = "HouseTurnover",
                Value = raw.HouseTurnover,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "HouseGrossIncome",
                Value = raw.HouseGrossIncome,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "HouseComm",
                Value = raw.HouseComm,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
            columns.Add(new Columns
            {
                Name = "HouseNetIncome",
                Value = raw.HouseNetIncome,
                CellAlignment = HAlignment.Right,
                CustomCellType = ExcelCellType.DoubleRedNegative
            });
        }
    }
}