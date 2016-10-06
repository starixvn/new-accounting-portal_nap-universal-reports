using System;
using System.Linq;
using System.Reflection;
using UniversalReports.Core.SortServices;

namespace UniversalReports.NG2Statistic.Data.UserName
{
    public class UserNameServiceImp : UserNameService
    {
        private Repository repository;

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
            UserNameModel daily = Query(queryModel);
            SortData(daily, queryModel);

            return daily;
        }

        private void SortData(UserNameModel raw, QueryModel queryModel)
        {
            PropertyInfo propInfo = typeof(UserNameModel).GetProperty(queryModel.SortColumnName);
            bool isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
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