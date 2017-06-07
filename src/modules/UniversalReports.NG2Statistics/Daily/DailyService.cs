using AutoMapper;
using Fanex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistics.BaseServices;
using UniversalReports.NG2Statistics.SortUtility;

namespace UniversalReports.NG2Statistics.Daily
{
    public interface DailyService
    {
        DailyModel Query(QueryModel queryModel);

        DailyModel SortData(DailyModel dataRaw, QueryModel queryModel);
    }

    public class DailyServiceImp : DailyService
    {
        private readonly BalanceUpService balance;

        public DailyServiceImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public DailyModel Query(QueryModel queryModel)
        {
            var daily = new DailyModel { Total = new DailyModel() };

            var dataRaw = DataRaw(queryModel);
            var dates = dataRaw.Rows.Select(s => s.Winlostdate).Distinct().ToList();
            foreach (var date in dates)
            {
                var dateByDate = dataRaw.Rows.Where(s => s.Winlostdate == date).ToList();
                daily.Rows.Add(new DailyModel { Rows = dateByDate });
            }

            daily.Total = dataRaw.Total;

            return daily;
        }

        private DailyModel DataRaw(QueryModel queryModel)
        {
            var daily = new DailyModel
            {
                Rows = new List<DailyModel>(),
                Total = new DailyModel()
            };

            var criteria = Mapper.Map<DailyCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var rows = multi.Read<DailyModel>();
                    var total = multi.Read<DailyModel>().FirstOrDefault();
                    total.Name = "Grand Total RM";

                    daily.Rows = rows.ToList();
                    daily.Total = total;
                }
            }

            return daily;
        }

        public DailyModel SortData(DailyModel dataRaw, QueryModel queryModel)
        {
            Sorting(dataRaw, queryModel);

            return dataRaw;
        }

        private static void Sorting(DailyModel raw, QueryModel queryModel)
        {
            foreach (var row in raw.Rows)
            {
                Sort.SortDataByProperty(row.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }

            var propInfo = typeof(DailyModel).GetProperty(queryModel.SortColumnName);
            var isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
            var orderStatement = isAsc
                ? raw.Rows.OrderBy(s => propInfo.GetValue(s.Rows[0], null))
                : raw.Rows.OrderByDescending(s => propInfo.GetValue(s.Rows[0], null));
            raw.Rows = orderStatement.ToList();
        }
    }
}