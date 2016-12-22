using System.Collections.Generic;
using System.Linq;
using Fanex.Data;

namespace UniversalReports.NG2Statistic.Bettype
{
    public class RepositoryImp : Repository
    {
        public BettypeModel QueryRawData(BettypeCriteria criteria)
        {
            var bettype = new BettypeModel
            {
                Rows = new List<BettypeModel>(),
                Total = new BettypeModel()
            };

            using (var db = new ObjectDb(criteria.GetSettingKey()))
            {
                using (var multi = db.QueryMultiple(criteria.GetSpParams()))
                {
                    var rows = multi.Read<BettypeModel>();
                    var total = multi.Read<BettypeModel>().FirstOrDefault();

                    bettype.Rows = rows.ToList();
                    bettype.Total = total;
                }
            }

            return bettype;
        }
    }
}