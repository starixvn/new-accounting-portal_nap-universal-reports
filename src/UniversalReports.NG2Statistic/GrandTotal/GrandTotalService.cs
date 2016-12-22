using UniversalReports.NG2Statistic.BaseServices;

namespace UniversalReports.NG2Statistic.GrandTotal
{
    public interface GrandTotalService
    {
        GrandTotalModel Query(QueryModel queryModel);
    }
}