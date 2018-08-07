using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Bettype
{
    public class BetTypeActualMemberBet : BaseModel
    {
        public string BettypeName { get; set; }

        public decimal MemberTurnoverMYOdds { get; set; }

        public static BetTypeActualMemberBet operator +(BetTypeActualMemberBet a, BetTypeActualMemberBet b)
        {
            return new BetTypeActualMemberBet
            {
                BettypeName = "Grand Total",
                MemberTurnoverMYOdds = a.MemberTurnoverMYOdds + b.MemberTurnoverMYOdds,
                BetCount = a.BetCount + b.BetCount,
                MemberTurnoverRM = a.MemberTurnoverRM + b.MemberTurnoverRM,
                MemberNetWinLoss = a.MemberNetWinLoss + b.MemberNetWinLoss,
                HouseRealTurnover = a.HouseRealTurnover + b.HouseRealTurnover,
                HouseVirtualTurnover = a.HouseVirtualTurnover + b.HouseVirtualTurnover,
                HouseRealIncome = a.HouseRealIncome + b.HouseRealIncome,
                HouseVirtualWinLoss = a.HouseVirtualWinLoss + b.HouseVirtualWinLoss
            };
        }
    }
}
