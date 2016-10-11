using System;
using System.Collections.Generic;
using System.Linq;
using Fanex.Data;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Factory;
using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistic.BaseServices;

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
            var sportTypes = dataRaw.Rows.Select(s => new { s.SportId, s.Sporttype }).Distinct().ToList();
            foreach (var sportType in sportTypes)
            {
                var bettypesBySportId = dataRaw.Rows.Where(s => s.SportId == sportType.SportId).ToList();
                bettype.Rows.Add(new BettypeModel { Rows = bettypesBySportId, SportId = sportType.SportId, Sporttype = sportType.Sporttype });
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
                    total.Bettype = "Grand Total RM";

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