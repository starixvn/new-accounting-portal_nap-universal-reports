using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.UserName
{
    public interface UserNameService
    {
        UserNameModel Query(QueryModel queryModel);

        UserNameModel SortData(QueryModel queryModel);
    }
}