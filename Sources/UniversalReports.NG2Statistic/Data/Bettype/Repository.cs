namespace UniversalReports.NG2Statistic.Data.Bettype
{
    public interface Repository
    {
        BettypeModel Query(QueryModel queryModel);
    }
}