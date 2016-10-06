using UniversalReports.NG2Statistic.Common;

namespace UniversalReports.NG2Statistic.UserName
{
    public interface UserNameService
    {
        UserNameModel Query(QueryModel queryModel);

        UserNameModel SortData(QueryModel queryModel);
    }
}