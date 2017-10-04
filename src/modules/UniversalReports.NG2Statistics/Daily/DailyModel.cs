using System;
using System.Collections.Generic;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Daily
{
    public class DailyModel : BaseModel
    {
        public DailyModel()
        {
            Rows = new List<DailyModel>();
        }

        public string Name { get; set; }

        public DateTime Winlostdate { get; set; }

        public int NoOfPlayers { get; set; }

        public List<DailyModel> Rows { get; set; }

        public DailyModel Total { get; set; }
    }
}