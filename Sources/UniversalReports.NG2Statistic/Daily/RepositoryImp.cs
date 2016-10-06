using Fanex.Common;
using Fanex.Data;
using System;
using System.Collections.Generic;
using System.Data;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Factory;
using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Daily
{
    public class RepositoryImp : Repository
    {
        private readonly BalanceUpService balance;

        public RepositoryImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public DailyModel Query(QueryModel queryModel)
        {
            var daily = new DailyModel
            {
                Rows = new List<DailyModel>(),
                Total = new DailyModel()
            };

            var criteria = CriteriaFactory.Transform<DailyCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(criteria.GetSpParams());
                var reader = db.ExecuteReader();
                while (reader.Read())
                {
                    var row = AssignData(reader);
                    row.Name = Converter.To<DateTime>(reader["WinlostDate"]).ToString("MMM dd, yyyy");
                    row.CurrencyId = Converter.To<int>(reader["CurrencyId"]);
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

        private DailyModel AssignData(IDataReader reader)
        {
            return new DailyModel
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
                CompanyNetIncome = Converter.To<decimal>(reader["CompanyNetIncome"])
            };
        }
    }
}