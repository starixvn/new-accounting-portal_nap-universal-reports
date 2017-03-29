namespace UniversalReports.PunterAnalysis.SportType.Model
{
    public class SportTypeModel
    {
        public int SportId { get; set; }

        public string SportName { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static SportTypeModel operator +(SportTypeModel firstObject, SportTypeModel secondObject)
        {
            return new SportTypeModel
            {
                SportId = 0,
                SportName = string.Empty,
                WinLoss = firstObject.WinLoss + secondObject.WinLoss,
                BetCount = firstObject.BetCount + secondObject.BetCount,
                Turnover = firstObject.Turnover + secondObject.Turnover
            };
        }
    }
}