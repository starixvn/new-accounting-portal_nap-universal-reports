using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Data.Daily
{
    public class DailyCriteria : CommonCriteria
    {
        public bool IsDrillDown { get; set; }

        public override string GetSettingKey()
        {
            return "NG2-Statistics-Daily";
        }        
    }
}
