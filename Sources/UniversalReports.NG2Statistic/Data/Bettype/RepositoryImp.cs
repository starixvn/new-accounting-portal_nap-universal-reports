using System.Collections.Generic;
using System.Data;
using Fanex.Common;
using Fanex.Data;
using UniversalReports.Common.BalanceUpServices;
using UniversalReports.Common.Criteria;

namespace UniversalReports.NG2Statistic.Data.Bettype
{
    public class RepositoryImp : Repository
    {
        private BalanceUpService balance;

        public RepositoryImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public BettypeModel Query(QueryModel queryModel)
        {
            BettypeModel bettype = new BettypeModel();
            bettype.Rows = new List<BettypeModel>();
            bettype.Total = new BettypeModel();

            var criteria = CriteriaFactory.Transform<BettypeCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(criteria.GetSpParams());
                var reader = db.ExecuteReader();
                while (reader.Read())
                {
                    var row = AssignData(reader);
                    row.Name = Converter.To<string>(reader["Sporttype"]);
                    row.SportId = Converter.To<int>(reader["SportId"]);
                    row.Bettype = Converter.To<string>(reader["Bettype"]);
                    row.BettypeId = Converter.To<int>(reader["BettypeId"]);
                    row.CurrencyId = Converter.To<int>(reader["CurrencyId"]);
                    bettype.Rows.Add(row);
                }

                reader.NextResult();
                while (reader.Read())
                {
                    var total = AssignData(reader);
                    total.Name = "Grand Total RM";
                    bettype.Total = total;
                }
            }

            return bettype;
        }

        private BettypeModel AssignData(IDataReader reader)
        {
            return new BettypeModel()
            {
                NoOfPlayers = Converter.To<int>(reader["NoOfPlayers"]),
                BetCount = Converter.To<int>(reader["BetCount"]),
                Currency = Converter.To<string>(reader["Currency"]),
                TotalBets = Converter.To<decimal>(reader["TotalBets"]),
                TotalWins = Converter.To<decimal>(reader["TotalWins"]),
                GameIncome = Converter.To<decimal>(reader["GameIncome"]),
                GamePayout = Converter.To<decimal>(reader["GamePayout"]),
                CompanyTurnover = Converter.To<decimal>(reader["CompanyTurnover"]),
                CompanyComm = Converter.To<decimal>(reader["CompanyComm"]),
                CompanyNetIncome = Converter.To<decimal>(reader["CompanyNetIncome"]),
            };
        }
    }
}