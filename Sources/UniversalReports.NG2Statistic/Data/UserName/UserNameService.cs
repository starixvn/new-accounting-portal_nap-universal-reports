namespace UniversalReports.NG2Statistic.Data.UserName
{
    public interface UserNameService
    {
        UserNameModel Query(QueryModel queryModel);

        UserNameModel SortData(QueryModel queryModel);
    }
}