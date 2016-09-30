using System.Collections.Generic;
using System.Data;
using Fanex.Common;
using Fanex.Data;
using UniversalReports.Common.BalanceUpServices;
using UniversalReports.Common.Criteria;

namespace UniversalReports.NG2Statistic.Data.UserName
{
    public class RepositoryImp : Repository
    {
        private BalanceUpService balance;

        public RepositoryImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public UserNameModel Query(QueryModel queryModel)
        {
            UserNameModel daily = new UserNameModel();
            daily.Rows = new List<UserNameModel>();
            daily.Total = new UserNameModel();

            var criteria = CriteriaFactory.Transform<UserNameCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(criteria.GetSpParams());
                var reader = db.ExecuteReader();
                while (reader.Read())
                {
                    var row = AssignData(reader);
                    row.Name = Converter.To<string>(reader["UserName"]);
                    row.CustId = Converter.To<int>(reader["CustId"]);
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

        private UserNameModel AssignData(IDataReader reader)
        {
            return new UserNameModel()
            {
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