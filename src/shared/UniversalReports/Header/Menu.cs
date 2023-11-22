namespace UniversalReports.Header
{
    using System.Collections.Generic;

    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public List<Menu> Children { get; set; }
    }
}