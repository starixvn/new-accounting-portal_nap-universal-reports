using System;
using System.Collections.Generic;
using System.Linq;
using Fanex.Data;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Factory;
using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class BettypeServiceImp : BettypeService
    {
        private readonly BalanceUpService balance;

        public BettypeServiceImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public BettypeModel Query(QueryModel queryModel)
        {
            var bettype = new BettypeModel { Total = new BettypeModel() };

            var dataRaw = DataRaw(queryModel);
            var sportTypeIds = dataRaw.Rows.Select(s => s.SportId).Distinct().ToList();
            foreach (var sportTypeId in sportTypeIds)
            {
                var bettypesBySportId = dataRaw.Rows.Where(s => s.SportId == sportTypeId).ToList();
                bettype.Rows.Add(new BettypeModel { Rows = bettypesBySportId });
            }

            bettype.Total = dataRaw.Total;

            return bettype;
        }

        private BettypeModel DataRaw(QueryModel queryModel)
        {
            var bettype = new BettypeModel
            {
                Rows = new List<BettypeModel>(),
                Total = new BettypeModel()
            };

            var criteria = CriteriaFactory.Transform<BettypeCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var rows = multi.Read<BettypeModel>();
                    var total = multi.Read<BettypeModel>().FirstOrDefault();
                    total.Sporttype = "Grand Total RM";

                    bettype.Rows = rows.ToList();
                    bettype.Total = total;
                }
            }

            return bettype;
        }

        public BettypeModel SortData(QueryModel queryModel)
        {
            var bettype = Query(queryModel);
            SortData(bettype, queryModel);

            return bettype;
        }

        private void SortData(BettypeModel raw, QueryModel queryModel)
        {
            foreach (var row in raw.Rows)
            {
                Sort.SortDataByProperty(row.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }

            var propInfo = typeof(BettypeModel).GetProperty(queryModel.SortColumnName);
            var isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
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