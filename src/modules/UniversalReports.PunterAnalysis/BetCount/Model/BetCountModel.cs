using System;

namespace UniversalReports.PunterAnalysis.BetCount.Model
{
    public class BetCountModel
    {
        public DateTime Date { get; set; }

        public int BetCount { get; set; }

        public int WinCount { get; set; }

        public int DrawCount { get; set; }

        public decimal WinLoss { get; set; }

        public static BetCountModel operator +(BetCountModel a, BetCountModel b)
        {
            return Add(a, b);
        }

        public static BetCountModel Add(BetCountModel a, BetCountModel b)
        {
            return new BetCountModel
            {
                Date = DateTime.MinValue,
                BetCount = a.BetCount + b.BetCount,
                WinCount = a.WinCount + b.WinCount,
                DrawCount = a.DrawCount + b.DrawCount,
                WinLoss = a.WinLoss + b.WinLoss
            };
        }

        public static bool operator ==(BetCountModel a, BetCountModel b)
        {
            return a.Date == b.Date
                && a.BetCount == b.BetCount
                && a.WinCount == b.WinCount
                && a.DrawCount == b.DrawCount
                && a.WinLoss == b.WinLoss;
        }

        public static bool operator !=(BetCountModel a, BetCountModel b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var good = obj as BetCountModel;
            return obj != null && this == good;
        }
    }
}