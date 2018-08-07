using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Product
{
    public class ProductActualMemberBet : BaseModel
    {
        public string ProductName { get; set; }

        public static ProductActualMemberBet operator +(ProductActualMemberBet a, ProductActualMemberBet b)
        {
            return new ProductActualMemberBet
            {
                ProductName = "Grand Total",
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
