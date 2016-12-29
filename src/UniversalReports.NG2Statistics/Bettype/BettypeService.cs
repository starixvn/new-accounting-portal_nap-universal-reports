using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public interface BettypeService
    {
        BettypeModel Query(QueryModel queryModel);
    }
}