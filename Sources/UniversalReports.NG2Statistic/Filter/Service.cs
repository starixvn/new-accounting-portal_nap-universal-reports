using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Filter
{
    public interface Service
    {
        List<Sport> QuerySports(SportCriteria criteria);

        List<dynamic> QueryUserNames(UserSearchCriteria criteria);

        List<Entity> QueryCurrency(CurrencyCriteria criteria);
        
    }
}
