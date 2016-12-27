using System.Collections.Generic;

namespace UniversalReports.NG2Statistics.Filter
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