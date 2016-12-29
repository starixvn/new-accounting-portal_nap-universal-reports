namespace UniversalReports.NG2Statistics.Bettype
{
    public interface Repository
    {
        BettypeModel QueryRawData(BettypeCriteria criteria);
    }
}