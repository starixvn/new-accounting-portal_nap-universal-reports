using System.Collections.Generic;
using System.Data;
using Fanex.Common;
using Fanex.Data;
using UniversalReports.Common.BalanceUpServices;
using UniversalReports.Common.Criteria;

namespace UniversalReports.NG2Statistic.Data.GrandTotal
{
    public class RepositoryImp : Repository
    {
        private BalanceUpService balance;

        public RepositoryImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public GrandTotalModel Query(QueryModel queryModel)
        {
            GrandTotalModel daily = new GrandTotalModel();
            daily.Rows = new List<GrandTotalModel>();
            daily.Total = new GrandTotalModel();

            var criteria = CriteriaFactory.Transform<GrandTotalCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(criteria.GetSpParams());
                var reader = db.ExecuteReader();
                while (reader.Read())
                {
                    var row = AssignData(reader);
                    row.Name = Converter.To<string>(reader["Currency"]);
                    daily.Rows.Add(row);
                }

                reader.NextResult();
                while (reader.Read())
                {
                    var total = AssignData(reader);
                    total.Name = "Grand Total RM";
                    daily.Total = total;
                }
            }

            return daily;
        }

        private GrandTotalModel AssignData(IDataReader reader)
        {
            return new GrandTotalModel()
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