using System.Collections.Generic;

namespace UniversalReports.Application.Menu
{
    public class Menu
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public List<Menu> Children { get; set; }
    }
}
