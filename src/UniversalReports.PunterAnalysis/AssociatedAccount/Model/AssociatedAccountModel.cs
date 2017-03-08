namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class AssociatedAccountModel
    {
        public string Username { get; set; }

        public decimal WinLoss { get; set; }

        public decimal Turnover { get; set; }

        public decimal Margin => Turnover == 0 ? 0 : WinLoss / Turnover;

        public int BetCount { get; set; }

        public static AssociatedAccountModel operator +(AssociatedAccountModel firstObject, AssociatedAccountModel secondObject)
        {
            return new AssociatedAccountModel
            {
                Username = string.Empty,
                WinLoss = firstObject.WinLoss + secondObject.WinLoss,
                BetCount = firstObject.BetCount + secondObject.BetCount,
                Turnover = firstObject.Turnover + secondObject.Turnover
            };
        }
    }
}