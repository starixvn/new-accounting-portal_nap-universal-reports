using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Fanex.Data;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistics.BaseServices;
using UniversalReports.NG2Statistics.SortUtility;

namespace UniversalReports.NG2Statistics.UserName
{
    public interface UserNameService
    {
        UserNameModel Query(QueryModel queryModel);

        UserNameModel SortData(QueryModel queryModel);
    }

    public class UserNameServiceImp : UserNameService
    {
        private readonly BalanceUpService balance;

        public UserNameServiceImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public UserNameModel Query(QueryModel queryModel)
        {
            var daily = new UserNameModel
            {
                Rows = new List<UserNameModel>(),
                Total = new UserNameModel()
            };

            var criteria = Mapper.Map<UserNameCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var rows = multi.Read<UserNameModel>();
                    var total = multi.Read<UserNameModel>().FirstOrDefault();
                    total.Username = "Grand Total RM";

                    daily.Rows = rows.ToList();
                    daily.Total = total;
                }
            }

            return daily;
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