using System.Web.Http;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using Criteria = UniversalReports.CompanyWinLoss.NumberGame.Site.Criteria;
using QueryModel = UniversalReports.CompanyWinLoss.NumberGame.Site.QueryModel;
using Service = UniversalReports.CompanyWinLoss.NumberGame.Summary.Service;
using WinLossModel = UniversalReports.CompanyWinLoss.NumberGame.Summary.WinLossModel;

namespace UniversalReports.CompanyWinLoss.NumberGame
{
    public class NumberGameController : ApiController
    {
        private readonly Service _summaryService;

        private readonly MatchDetail.Service _detailService;

        private readonly SiteWinLossService _siteService;

        public NumberGameController(
            Service summaryService,
            MatchDetail.Service detailService,
            SiteWinLossService siteWinLossService)
        {
            _summaryService = summaryService;
            _detailService = detailService;
            _siteService = siteWinLossService;
        }

        public WinLossModel Summary(Summary.QueryModel queryModel)
        {
            var criteria = new Summary.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate
            };

            return ModelState.IsValid
                ? _summaryService.Query(criteria)
                : null;
        }

        public MatchDetail.WinLossModel MatchDetail(MatchDetail.QueryModel queryModel)
        {
            var criteria = new MatchDetail.Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                BetType = queryModel.BetType,
                IsLive = queryModel.IsLive,
                SportType = queryModel.SportType
            };

            return ModelState.IsValid
                ? _detailService.Query(criteria)
                : null;
        }

        public SiteWinLoss SiteWinLoss(QueryModel queryModel)
        {
            var criteria = new Criteria
            {
                StartDate = queryModel.StartDate,
                EndDate = queryModel.EndDate,
                SportType = queryModel.SportType,
                BetType = queryModel.BetType,
                IsLive = queryModel.IsLive,
                Site = queryModel.Site
            };

            return ModelState.IsValid
                ? _siteService.Query(criteria)
                : null;
        }
    }
}
