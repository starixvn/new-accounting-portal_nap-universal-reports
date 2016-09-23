using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Filter
{
    public interface Service
    {
        List<Sport> Query(SportCriteria criteria);
    }
}
