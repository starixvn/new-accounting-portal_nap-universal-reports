using System;
using System.Linq;
using System.Reflection;
using UniversalReports.Core.SortServices;

namespace UniversalReports.NG2Statistic.Data.Bettype
{
    public class BettypeServiceImp : BettypeService
    {
        private Repository repository;

        public BettypeServiceImp(Repository repository)
        {
            this.repository = repository;
        }

        public BettypeModel Query(QueryModel queryModel)
        {
            BettypeModel bettype = new BettypeModel();
            bettype.Total = new BettypeModel();

            var rawData = repository.Query(queryModel);
            var sportTypeIds = rawData.Rows.Select(s => s.SportId).Distinct().ToList();
            foreach (var sportTypeId in sportTypeIds)
            {
                var bettypesBySportId = rawData.Rows.Where(s => s.SportId == sportTypeId).ToList();
                bettype.Rows.Add(new BettypeModel() { Rows = bettypesBySportId });
            }

            bettype.Total = rawData.Total;

            return bettype;
        }

        public BettypeModel SortData(QueryModel queryModel)
        {
            BettypeModel bettype = Query(queryModel);
            SortData(bettype, queryModel);

            return bettype;
        }

        private void SortData(BettypeModel raw, QueryModel queryModel)
        {
            foreach (var row in raw.Rows)
            {
                Sort.SortDataByProperty<BettypeModel>(row.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }

            PropertyInfo propInfo = typeof(BettypeModel).GetProperty(queryModel.SortColumnName);
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