using System.Collections.Generic;

namespace UniversalReports.Application.Header
{
    public class Header
    {
        public string Username { get; set; }

        public IList<Menu> Menus { get; set; }
    }
}