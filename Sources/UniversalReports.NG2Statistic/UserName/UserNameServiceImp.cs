using System;
using System.Linq;
using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.UserName
{
    public class UserNameServiceImp : UserNameService
    {
        private readonly Repository repository;

        public UserNameServiceImp(Repository repository)
        {
            this.repository = repository;
        }

        public UserNameModel Query(QueryModel queryModel)
        {
            return repository.Query(queryModel);
        }

        public UserNameModel SortData(QueryModel queryModel)
        {
            var daily = Query(queryModel);
            SortData(daily, queryModel);

            return daily;
        }

        private void SortData(UserNameModel raw, QueryModel queryModel)
        {
            var propInfo = typeof(UserNameModel).GetProperty(queryModel.SortColumnName);
            var isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc,
                StringComparison.OrdinalIgnoreCase);
            if (isAsc)
            {
                raw.Rows = raw
                    .Rows
                    .OrderBy(s => propInfo.GetValue(s, null))
                    .ToList();
            }
            else
            {
                raw.Rows = raw
                    .Rows
                    .OrderByDescending(s => propInfo.GetValue(s, null))
                    .ToList();
            }
        }
    }
}