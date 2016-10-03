using System.Collections.Generic;
using Fanex.Excel.Enums;
using Fanex.Excel.Models;

namespace UniversalReports.NG2Statistic.Data.Bettype
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
                ShowFooter = true,
            };
        }

        private List<GridDataRow> BuildBodyRows(BettypeModel bettypeModel)
        {
            int index = 0;
            int indexGroup = 0;
            string cssClass = string.Empty;
            var gridRows = new List<GridDataRow>();
            foreach (var sportType in bettypeModel.Rows)
            {
                cssClass = indexGroup % 2 == 0 ? string.Empty : "parent-level-0";
                foreach (var bettype in sportType.Rows)
                {
                    var gridRow = BuildDataRow(bettype, cssClass, index == 0);
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
            return new List<GridDataRow>() { BuildDataTotalRow(total) };
        }

        private GridDataRow BuildDataRow(BettypeModel raw, string cssClass, bool isSport)
        {
            var columns = new List<Columns>();
            AssignDataRow(raw, columns, isSport);
            if (isSport)
            {
                cssClass = cssClass + " ng2-sport-bold";
            }

            return new GridDataRow { Columns = columns, CssClass = cssClass, };
        }

        private GridDataRow BuildDataTotalRow(BettypeModel raw)
        {
            var columns = new List<Columns>();
            AssignDataRow(raw, columns, true);

            return new GridDataRow { Columns = columns };
        }

        private void AssignDataRow(BettypeModel raw, List<Columns> columns, bool isSport)
        {
            if (isSport)
            {
                columns.Add(new Columns { Name = "Name", Value = raw.Name, Bold = true, CellAlignment = HAlignment.Left });
            }
            else
            {
                columns.Add(new Columns { Name = "Name", Value = raw.Bettype, Bold = false, CellAlignment = HAlignment.Right });
            }
            
            columns.Add(new Columns { Name = "NoOfPlayers", Value = raw.NoOfPlayers, CustomAttributes = raw.SportId.ToString() });
            columns.Add(new Columns { Name = "BetCount", Value = raw.BetCount, CustomAttributes = raw.BettypeId.ToString() });
            columns.Add(new Columns { Name = "Currency", Value = raw.Currency, CustomAttributes = raw.CurrencyId.ToString() });
            columns.Add(new Columns { Name = "TotalBets", Value = raw.TotalBets });
            columns.Add(new Columns { Name = "TotalWins", Value = raw.TotalWins });
            columns.Add(new Columns { Name = "GameIncome", Value = raw.GameIncome });
            columns.Add(new Columns { Name = "GamePayout", Value = raw.GamePayout });
            columns.Add(new Columns { Name = "CompanyTurnover", Value = raw.CompanyTurnover });
            columns.Add(new Columns { Name = "CompanyComm", Value = raw.CompanyComm });
            columns.Add(new Columns { Name = "CompanyNetIncome", Value = raw.CompanyNetIncome });
        }
    }
}