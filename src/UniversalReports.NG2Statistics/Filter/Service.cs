using System.Collections.Generic;

namespace UniversalReports.NG2Statistics.Filter
{
    public interface Service
    {
        List<Sport> QuerySports(SportCriteria criteria);

        List<UserNameModel> QueryUserNames(UserSearchCriteria criteria);

        List<Entity> QueryCurrency(CurrencyCriteria criteria);
    }
}