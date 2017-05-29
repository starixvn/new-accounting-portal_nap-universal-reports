using AutoMapper;
using Fanex.Data;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.GrandTotal
{
    public interface GrandTotalService
    {
        GrandTotalModel Query(QueryModel queryModel);
    }

    public class GrandTotalServiceImp : GrandTotalService
    {
        private readonly BalanceUpService balance;

        public GrandTotalServiceImp(BalanceUpService balance)
        {
            this.balance = balance;
        }

        public GrandTotalModel Query(QueryModel queryModel)
        {
            var daily = new GrandTotalModel
            {
                Rows = new List<GrandTotalModel>(),
                Total = new GrandTotalModel()
            };

            var criteria = Mapper.Map<GrandTotalCriteria>(queryModel);
            criteria.MoveBetsDay = balance.Query().MoveBetsDate;

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var rows = multi.Read<GrandTotalModel>();
                    var total = multi.Read<GrandTotalModel>().FirstOrDefault();

                    daily.Rows = rows.ToList();
                    daily.Total = total;
                }
            }

            return daily;
        }
    }
}