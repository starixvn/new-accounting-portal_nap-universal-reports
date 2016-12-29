using UniversalReports.Core.SortUtility;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public class SortingServiceImp : SortingService
    {
        public void SortingData(BettypeModel bettypeModel, QueryModel queryModel)
        {
            foreach (var sporttype in bettypeModel.Rows)
            {
                foreach (var bettype in sporttype.Rows)
                {
                    Sort.SortDataByProperty(bettype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
                }

                Sort.SortDataByProperty(sporttype.Rows, queryModel.SortDirection, queryModel.SortColumnName);
            }
        }
    }
}