using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.GrandTotal
{
    public interface GrandTotalService
    {
        GrandTotalModel Query(QueryModel queryModel);
    }
}