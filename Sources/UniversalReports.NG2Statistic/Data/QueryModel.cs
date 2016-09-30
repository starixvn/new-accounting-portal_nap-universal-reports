using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Data
{
    public class QueryModel
    {
        private Dictionary<string, string> dataTypes;
        public QueryModel()
        {
            dataTypes = new Dictionary<string, string>()
            {
                { "Name", "date"},
                { "NoOfPlayers", "number" },
                { "BetCount", "number" },
                { "Currency", "string" },
                { "TotalBets", "number" },
                { "TotalWins", "number" },
                { "GameIncome", "number" },
                { "GamePayout", "number" },
                { "CompanyTurnover", "number" },
                { "CompanyComm", "number" },
                { "CompanyNetIncome", "number" },
            };

            SortColumnName = string.Empty;
            SortDirection = string.Empty;

        }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime MoveBetsDay { get; set; }

        public string UserName { get; set; }

        public string BetType { get; set; }

        public short LiveStatus { get; set; } = -1;

        public short Currency { get; set; }

        public bool IsRealTime { get; set; } = true;

        public string Title { get; set; }

        public string SortColumnName { get; set; }

        public string SortDirection { get; set; }

        public string SortDataType
        {
            get
            {
                if (string.IsNullOrEmpty(SortColumnName))
                    return string.Empty;

                return dataTypes.ContainsKey(SortColumnName) ? dataTypes[SortColumnName] : string.Empty;
            }
        }
    }
}
