namespace UniversalReports.NG2Statistic.Data.UserName
{
    public interface Repository
    {
        UserNameModel Query(QueryModel queryModel);
    }
}