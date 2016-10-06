using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.UserName
{
    public interface Repository
    {
        UserNameModel Query(QueryModel queryModel);
    }
}