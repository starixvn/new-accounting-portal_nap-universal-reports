using System;
using System.Linq;
using System.Reflection;
using UniversalReports.Common.SortServices;

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
            foreach (var date in dates)
            {
                var dateByDate = rawData.Rows.Where(s => s.Name == date).ToList();
                daily.Rows.Add(new DailyRaw() { Rows = dateByDate });
            }

            daily.Total = rawData.Total;           

            return daily;
        }

        public DailyRaw SortData(QueryModel queryModel)
        {
            DailyRaw daily = Query(queryModel);
            SortData(daily, queryModel);

            return daily;
        }

        private void SortData(DailyRaw raw, QueryModel queryModel)
        {
            foreach (var row in raw.Rows)
            {
                Sort.SortDataByProperty<DailyRaw>(row.Rows, queryModel.SortDirection, queryModel.SortColumnName, queryModel.SortDataType);
            }

            PropertyInfo propInfo = typeof(DailyRaw).GetProperty(queryModel.SortColumnName);
            bool isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
            if (isAsc)
            {
                raw.Rows = raw
                    .Rows
                    .OrderBy(s => propInfo.GetValue(s.Rows[0], null))
                    .ToList();
            }
            else
            {
                raw.Rows = raw
                    .Rows
                    .OrderByDescending(s => propInfo.GetValue(s.Rows[0], null))
                    .ToList();
            }
        }
    }
}