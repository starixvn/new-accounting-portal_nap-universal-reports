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

        public static BetCountModel operator +(BetCountModel firstObject, BetCountModel secondObject)
        {
            return new BetCountModel
            {
                Date = DateTime.MinValue,
                BetCount = firstObject.BetCount + secondObject.BetCount,
                WinCount = firstObject.WinCount + secondObject.WinCount,
                DrawCount = firstObject.DrawCount + secondObject.DrawCount,
                WinLoss = firstObject.WinLoss + secondObject.WinLoss
            };
        }
    }
}