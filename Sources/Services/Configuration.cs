using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class Configuration : IConfiguration
    {
        private static List<string> _products = new List<string>
        {
            "Sportsbook",
            "NumberGame",
            "LiveCasino",
            "Casino",
            "VirtualSports",
            "Keno",
            "Racing",
            "Bingo",
            "BetTrade",
            "ColossusBets"
        };

        public List<string> Products
        {
            get
            {
                return _products;
            }
        }
    }
}
