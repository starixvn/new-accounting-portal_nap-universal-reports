namespace UniversalReports.NG2Statistic.Bettype
{
    public interface Repository
    {
        BettypeModel QueryRawData(BettypeCriteria criteria);
    }
}