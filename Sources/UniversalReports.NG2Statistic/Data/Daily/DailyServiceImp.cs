using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fanex.Common;
using Fanex.Data;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class DailyServiceImp : DailyService
    {
        public DailyModel Query(DailyCriteria criteria)
        {
            DailyModel daily = new DailyModel();
            using (ObjectDb db = new ObjectDb(criteria.GetSettingKey()))
            {
                db.AssignParamValues(criteria.GetSpParams());
                var reader = db.ExecuteReader();
                while (reader.Read())
                {
                    var row =  AssignData(reader);
                    row.Name = Converter.To<DateTime>(reader["WinlostDate"]).ToString("MMM dd, yyyy");
                    row.CurrencyId = Converter.To<int>(reader["CurrencyId"]);
                    daily.Rows.Add(row);
                }

                reader.NextResult();
                while (reader.Read())
                {
                    var total = AssignData(reader);
                    total.Name = "Grand Total RM";
                    daily.GrandTotal.Add(total);
                }
            }

            return daily;
        }

        private DailyRaw AssignData(IDataReader reader)
        {
            return new DailyRaw() 
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
