using System.Collections.Generic;
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
            return userNameModel.Rows.Select(BuildDataRow).ToList();
        }

        private List<GridDataRow> BuildFooter(UserNameModel total)
        {
            return new List<GridDataRow>() { BuildDataRow(total) };
        }

        private GridDataRow BuildDataRow(UserNameModel raw)
        {
            var columns = new List<Columns>();
            columns.Add(new Columns { Name = "Name", Value = raw.Name });
            columns.Add(new Columns { Name = "CustId", Value = raw.CustId });
            columns.Add(new Columns { Name = "BetCount", Value = raw.BetCount });
            columns.Add(new Columns { Name = "Currency", Value = raw.Currency });
            columns.Add(new Columns { Name = "TotalBets", Value = raw.TotalBets });
            columns.Add(new Columns { Name = "TotalWins", Value = raw.TotalWins });
            columns.Add(new Columns { Name = "GameIncome", Value = raw.GameIncome });
            columns.Add(new Columns { Name = "GamePayout", Value = raw.GamePayout });
            columns.Add(new Columns { Name = "CompanyTurnover", Value = raw.CompanyTurnover });
            columns.Add(new Columns { Name = "CompanyComm", Value = raw.CompanyComm });
            columns.Add(new Columns { Name = "CompanyNetIncome", Value = raw.CompanyNetIncome });

            return new GridDataRow { Columns = columns };
        }
    }
}