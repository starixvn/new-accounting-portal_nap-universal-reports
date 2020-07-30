using AutoMapper;
using Fanex.Caching;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Web.Session;
using Linq.DynamicSum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Summary
{
    public interface WinLossService
    {
        Task<WinLossModel> GetSMAWinLoss(WinLossHttpParameter parameters);
    }

    public class WinLossServiceImp : WinLossService
    {
        private const string SMAWinLossSessionKey = "SMAWinLossRawDataKey";

        private readonly IDynamicRepository repository;

        private readonly ICurrentSession currentSession;

        private readonly ICacheService cacheService;

        public WinLossServiceImp(IDynamicRepository repository, ICurrentSession currentSession, ICacheService cacheService)
        {
            this.repository = repository;
            this.currentSession = currentSession;
            this.cacheService = cacheService;
        }

        public async Task<WinLossModel> GetSMAWinLoss(WinLossHttpParameter parameters)
        {
            var result = new WinLossModel();
            var pageIndex = parameters.PageIndex;
            var pageSize = parameters.PageSize / 5;

            var userNameWinLosses = new List<UsernameWinLoss>();
            var criteria = Mapper.Map<WinLossCriteria>(parameters);
            var fullRawData = await GetSummaryRawData(criteria, parameters.IsGenerated);
            result.TotalItems = fullRawData.Count() * 5;
            var rawData = fullRawData.Skip(pageIndex * pageSize).Take(pageSize);

            var usernameGroups = rawData.GroupBy(x => new { x.CustId, x.Username, x.Currency, x.VirtualRate });

            foreach (var group in usernameGroups)
            {
                var usernameGroupRawData = rawData.Where(
                    x => x.CustId == group.Key.CustId
                    && x.Username == group.Key.Username
                    && x.Currency == group.Key.Currency);

                var userNameTotal = usernameGroupRawData.DynamicSum();

                var usernameTurnover = new UsernameWinLoss
                {
                    CustId = group.Key.CustId,
                    Username = group.Key.Username,
                    Currency = group.Key.Currency,
                    Name = "Real Turnover",
                    VirtualRate = group.Key.VirtualRate,
                    Months = InitMonthlyValue(parameters.Year)
                };
                var usernameIncome = new UsernameWinLoss
                {
                    CustId = group.Key.CustId,
                    Username = group.Key.Username,
                    Currency = group.Key.Currency,
                    Name = "Real Income",
                    VirtualRate = group.Key.VirtualRate,
                    Months = InitMonthlyValue(parameters.Year)
                };
                var usernameMargin = new UsernameWinLoss
                {
                    CustId = group.Key.CustId,
                    Username = group.Key.Username,
                    Currency = group.Key.Currency,
                    Name = "Real Margin (%)",
                    VirtualRate = group.Key.VirtualRate,
                    Months = InitMonthlyValue(parameters.Year)
                };
                var usernameAvgPT = new UsernameWinLoss
                {
                    CustId = group.Key.CustId,
                    Username = group.Key.Username,
                    Currency = group.Key.Currency,
                    Name = "Average PT (%)",
                    VirtualRate = group.Key.VirtualRate,
                    Months = InitMonthlyValue(parameters.Year)
                };
                var usernameAvgBet = new UsernameWinLoss
                {
                    CustId = group.Key.CustId,
                    Username = group.Key.Username,
                    Currency = group.Key.Currency,
                    Name = "Average Bet",
                    VirtualRate = group.Key.VirtualRate,
                    Months = InitMonthlyValue(parameters.Year)
                };

                foreach (var monthlyRawDataByUsername in usernameGroupRawData)
                {
                    var date = $"{monthlyRawDataByUsername.RptDate:MMM, yyyy}";
                    usernameTurnover.Months.FirstOrDefault(x => x.Month == date).Value = monthlyRawDataByUsername.RealTurnover;
                    usernameIncome.Months.FirstOrDefault(x => x.Month == date).Value = monthlyRawDataByUsername.RealIncome;
                    usernameMargin.Months.FirstOrDefault(x => x.Month == date).Value = monthlyRawDataByUsername.RealMargin;
                    usernameAvgPT.Months.FirstOrDefault(x => x.Month == date).Value = monthlyRawDataByUsername.AvgPT;
                    usernameAvgBet.Months.FirstOrDefault(x => x.Month == date).Value = monthlyRawDataByUsername.AvgBet;
                }

                usernameTurnover.Months.FirstOrDefault(x => x.Month == "Total").Value = userNameTotal.RealTurnover;
                usernameIncome.Months.FirstOrDefault(x => x.Month == "Total").Value = userNameTotal.RealIncome;
                usernameAvgPT.Months.FirstOrDefault(x => x.Month == "Total").Value = userNameTotal.AvgPT;
                usernameMargin.Months.FirstOrDefault(x => x.Month == "Total").Value = userNameTotal.RealMargin;
                usernameAvgBet.Months.FirstOrDefault(x => x.Month == "Total").Value = userNameTotal.AvgBet;

                userNameWinLosses.AddRange(new List<UsernameWinLoss> { usernameTurnover, usernameIncome, usernameMargin, usernameAvgPT, usernameAvgBet });
            }

            var total = SumTotal(parameters.Year, rawData);

            result.UsernameWinLosses = userNameWinLosses;
            result.Total = total;

            return result;
        }

        private async Task<IEnumerable<WinLossEntity>> GetSummaryRawData(WinLossCriteria criteria, bool isGenerated)
        {
            var cacheKey = $"SMAWinLossSessionKey{currentSession.UserId}";
            var rawData = await cacheService.GetAsync<IEnumerable<WinLossEntity>>(cacheKey);

            if (isGenerated || rawData == null)
            {
                rawData = await repository.FetchAsync<WinLossEntity>(criteria);
                await cacheService.SetAsync(cacheKey, rawData);
            }

            return rawData;
        }

        private List<UsernameWinLoss> SumTotal(int year, IEnumerable<WinLossEntity> rawData)
        {
            var result = new List<UsernameWinLoss>();

            var totalTurnover = new UsernameWinLoss
            {
                Username = "Total",
                Name = "Real Turnover",
                Months = InitMonthlyValue(year)
            };

            var totalIncome = new UsernameWinLoss
            {
                Username = "Total",
                Name = "Real Income",
                Months = InitMonthlyValue(year)
            };

            var totalMargin = new UsernameWinLoss
            {
                Username = "Total",
                Name = "Real Margin (%)",
                Months = InitMonthlyValue(year)
            };

            var totalByMonth = SumTotalByMonth(rawData);

            foreach (var item in totalByMonth)
            {
                var date = $"{item.RptDate:MMM, yyyy}";
                totalTurnover.Months.FirstOrDefault(x => x.Month == date).Value = item.RealTurnover;
                totalIncome.Months.FirstOrDefault(x => x.Month == date).Value = item.RealIncome;
                totalMargin.Months.FirstOrDefault(x => x.Month == date).Value = item.RealMargin;
            }

            var allTotal = SumAllTotal(rawData);
            totalTurnover.Months.FirstOrDefault(x => x.Month == "Total").Value = allTotal.RealTurnover;
            totalIncome.Months.FirstOrDefault(x => x.Month == "Total").Value = allTotal.RealIncome;
            totalMargin.Months.FirstOrDefault(x => x.Month == "Total").Value = allTotal.RealMargin;

            result.AddRange(new List<UsernameWinLoss> { totalTurnover, totalIncome, totalMargin });

            return result;
        }

        private List<WinLossEntity> SumTotalByMonth(IEnumerable<WinLossEntity> rawData)
        {
            var result = new List<WinLossEntity>();

            var monthGroups = rawData.GroupBy(x => x.RptDate);

            foreach (var monthGroup in monthGroups)
            {
                var monthRawData = rawData.Where(x => x.RptDate == monthGroup.Key);
                var sumMonthlyWinLoss = monthRawData.DynamicSum();

                result.Add(sumMonthlyWinLoss);
            }

            return result;
        }

        private WinLossEntity SumAllTotal(IEnumerable<WinLossEntity> rawData)
        {
            return rawData.DynamicSum();
        }

        private List<MonthModel> InitMonthlyValue(int year)
        {
            var result = new List<MonthModel>();

            for (var i = 0; i < 12; i++)
            {
                result.Add(new MonthModel
                {
                    Month = $"{new DateTime(year, i + 1, 1):MMM, yyyy}"
                });
            }

            result.Add(new MonthModel
            {
                Month = "Total"
            });

            return result;
        }
    }
}