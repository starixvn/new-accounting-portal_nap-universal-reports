using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.NG2Statistic.Filter
{
    public class Sport
    {
        public Sport()
        {
            Name = string.Empty;
            Children = new List<Sport>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }

        public List<Sport> Children { get; set; }

    }
}
