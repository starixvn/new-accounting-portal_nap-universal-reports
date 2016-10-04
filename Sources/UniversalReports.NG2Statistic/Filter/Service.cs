using System.Collections.Generic;

namespace UniversalReports.NG2Statistic.Filter
{
    public interface Service
    {
        List<Sport> QuerySports(SportCriteria criteria);

        List<dynamic> QueryUserNames(UserSearchCriteria criteria);

        List<Entity> QueryCurrency(CurrencyCriteria criteria);
    }
}