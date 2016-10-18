using System;
using System.Linq;
using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class SortingServiceImp : SortingService
    {
        public void SortingData(BettypeModel bettypeModel, QueryModel queryModel)
        {
            if (queryModel.Currency == 0)
            {
                SortDataWithAllCurrency(bettypeModel, queryModel);
            }
            else
            {
                SortDataWithSpecificCurrency(bettypeModel, queryModel);
            }
        }

        private void SortDataWithAllCurrency(BettypeModel raw, QueryModel queryModel)
        {
            foreach (var sporttype in raw.Rows)
            {
                foreach (var bettype in sporttype.Rows)
                {
                    Sort.SortDataByProperty(bettype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
                }

                Sort.SortDataByProperty(sporttype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }
        }

        private void SortDataWithSpecificCurrency(BettypeModel raw, QueryModel queryModel)
        {
            foreach (var sporttype in raw.Rows)
            {
                foreach (var bettype in sporttype.Rows)
                {
                    Sort.SortDataByProperty(bettype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
                }

                Sort.SortDataByProperty(sporttype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }

            var propInfo = typeof(BettypeModel).GetProperty(queryModel.SortColumnName);
            if (propInfo == null)
            {
                return;
            }

            var isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
            if (isAsc)
            {
                raw.Rows = raw
                    .Rows
                    .OrderBy(s => propInfo.GetValue(s.Rows[0].Rows[0], null))
                    .ToList();
            }
            else
            {
                raw.Rows = raw
                    .Rows
                    .OrderByDescending(s => propInfo.GetValue(s.Rows[0].Rows[0], null))
                    .ToList();
            }
        }
    }
}