using System.Collections.Generic;
using UniversalReports.NG2Statistics.BaseServices;

namespace UniversalReports.NG2Statistics.Bettype
{
    public class BettypeModel : BaseModel
    {
        public BettypeModel()
        {
            Rows = new List<BettypeModel>();
        }

        public string Sporttype { get; set; }

        public int SportId { get; set; }

        public string Bettype { get; set; }

        public int BettypeId { get; set; }

        public int NoOfPlayers { get; set; }

        public List<BettypeModel> Rows { get; set; }

        public BettypeModel Total { get; set; }
    }
}