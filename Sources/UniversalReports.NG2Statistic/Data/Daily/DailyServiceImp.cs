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

        public DailyModel Query(QueryModel queryModel)
        {
            DailyModel daily = new DailyModel();
            daily.Total = new DailyModel();

            var rawData = repository.Query(queryModel);            
            var dates = rawData.Rows.Select(s => s.Name).Distinct().ToList();
            foreach (var date in dates)
            {
                var dateByDate = rawData.Rows.Where(s => s.Name == date).ToList();
                daily.Rows.Add(new DailyModel() { Rows = dateByDate });
            }

            daily.Total = rawData.Total;           

            return daily;
        }

        public DailyModel SortData(QueryModel queryModel)
        {
            DailyModel daily = Query(queryModel);
            SortData(daily, queryModel);

            return daily;
        }

        private void SortData(DailyModel raw, QueryModel queryModel)
        {
            foreach (var row in raw.Rows)
            {
                Sort.SortDataByProperty<DailyModel>(row.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }

            PropertyInfo propInfo = typeof(DailyModel).GetProperty(queryModel.SortColumnName);
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