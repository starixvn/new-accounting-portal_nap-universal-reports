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

        public static SportTypeModel operator +(SportTypeModel a, SportTypeModel b)
        {
            return Add(a, b);
        }

        public static SportTypeModel Add(SportTypeModel a, SportTypeModel b)
        {
            return new SportTypeModel
            {
                SportId = 0,
                SportName = string.Empty,
                WinLoss = a.WinLoss + b.WinLoss,
                BetCount = a.BetCount + b.BetCount,
                Turnover = a.Turnover + b.Turnover
            };
        }

        public static bool operator ==(SportTypeModel a, SportTypeModel b)
        {
            return a.BetCount == b.BetCount
                && a.WinLoss == b.WinLoss
                && a.Turnover == b.Turnover
                && a.SportName == b.SportName
                && a.SportId == b.SportId;
        }

        public static bool operator !=(SportTypeModel a, SportTypeModel b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var good = obj as SportTypeModel;
            return obj != null && this == good;
        }
    }
}