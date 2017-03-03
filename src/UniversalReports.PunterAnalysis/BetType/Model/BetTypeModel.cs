using System;

namespace UniversalReports.PunterAnalysis.BetType.Model
{
    public class BetTypeModel
    {
        public DateTime Date { get; set; }

        public int BetCount { get; set; }

        public int WinCount { get; set; }

        public int DrawCount { get; set; }

        public decimal WinLoss { get; set; }

        public static BetTypeModel operator +(BetTypeModel object1, BetTypeModel object2)
        {
            return new BetTypeModel
            {
                Date = DateTime.MinValue,
                BetCount = object1.BetCount + object2.BetCount,
                WinCount = object1.WinCount + object2.WinCount,
                DrawCount = object1.DrawCount + object2.DrawCount,
                WinLoss = object1.WinLoss + object2.WinLoss
            };
        }
    }
}