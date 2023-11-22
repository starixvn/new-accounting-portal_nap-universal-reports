using System;
using System.Linq;
using AutoMapper;
using Fanex.Data.Repository;
using UniversalReports.NG2Statistics.BaseServices;
using UniversalReports.NG2Statistics.SortUtility;

namespace UniversalReports.NG2Statistics.UserName
{
    using BalanceUpServices;

    public interface UserNameService
    {
        UserNameModel Query(QueryModel queryModel);

        UserNameModel SortData(QueryModel queryModel);
    }

    public class UserNameServiceImp : UserNameService
    {
        private readonly BalanceUpService balance;

        private readonly IDynamicRepository repository;

        public UserNameServiceImp(BalanceUpService balance, IDynamicRepository repository)
        {
            this.balance = balance;
            this.repository = repository;
        }

        public UserNameModel Query(QueryModel queryModel)
        {

            var criteria = Mapper.Map<UserNameCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            var rawData = repository.FetchMultiple<UserNameModel, UserNameModel>(criteria);
            var total = rawData.Item2.FirstOrDefault();
            total.Username = "Grand Total RM";

            return new UserNameModel
            {
                Rows = rawData.Item1.ToList(),
                Total = total
            };
        }

        public UserNameModel SortData(QueryModel queryModel)
        {
            var daily = Query(queryModel);
            SortData(daily, queryModel);

            return daily;
        }

        private static void SortData(UserNameModel raw, QueryModel queryModel)
        {
            var propInfo = typeof(UserNameModel).GetProperty(queryModel.SortColumnName);
            var isAsc = string.Equals(queryModel.SortDirection, SortDirectionConstants.Asc, StringComparison.OrdinalIgnoreCase);
            var orderStatement = isAsc
                ? raw.Rows.OrderBy(s => propInfo.GetValue(s, null))
                : raw.Rows.OrderByDescending(s => propInfo.GetValue(s, null));

            raw.Rows = orderStatement.ToList();
        }
    }
}