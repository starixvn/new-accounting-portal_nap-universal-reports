using System.Collections.Generic;
using System.Linq;
using Fanex.Data;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.Factory;
using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.GrandTotal
{
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

            var criteria = CriteriaFactory.Transform<GrandTotalCriteria>(queryModel);
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