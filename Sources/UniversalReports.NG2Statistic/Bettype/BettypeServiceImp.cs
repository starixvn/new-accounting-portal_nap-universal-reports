using System;
using System.Linq;
using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class BettypeServiceImp : BettypeService
    {
        private readonly Repository repository;

        public BettypeServiceImp(Repository repository)
        {
            this.repository = repository;
        }

        public BettypeModel Query(QueryModel queryModel)
        {
            var bettype = new BettypeModel { Total = new BettypeModel() };

            var rawData = repository.Query(queryModel);
            var sportTypeIds = rawData.Rows.Select(s => s.SportId).Distinct().ToList();
            foreach (var sportTypeId in sportTypeIds)
            {
                var bettypesBySportId = rawData.Rows.Where(s => s.SportId == sportTypeId).ToList();
                bettype.Rows.Add(new BettypeModel { Rows = bettypesBySportId });
            }

            bettype.Total = rawData.Total;

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