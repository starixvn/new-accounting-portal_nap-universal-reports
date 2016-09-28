using System;
using System.Data;
using Fanex.Common;
using Fanex.Data;
using UniversalReports.Common.BalanceUpServices;
using UniversalReports.Common.Criteria;
using System.Linq;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class DailyServiceImp : DailyService
    {
        private Repository repository;

        public DailyServiceImp(Repository repository)
        {
            this.repository = repository;
        }

        public DailyRaw Query(QueryModel queryModel)
        {
            DailyRaw daily = new DailyRaw();
            daily.Total = new DailyRaw();

            var rawData = repository.Query(queryModel);
            var dates = rawData.Rows.Select(s => s.Name).Distinct().ToList();
            foreach(var date in dates)
            {
                var dateByDate = rawData.Rows.Where(s => s.Name == date).ToList();
                daily.Rows.Add(new DailyRaw() { Rows = dateByDate });
            }

            daily.Total = rawData.Total;

            return daily;
        }        
    }
}