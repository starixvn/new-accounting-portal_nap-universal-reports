(function (angular) {
    'use strict';

    var templateSetting = {
        'Soccer': {
            product: 'soccer',
            soccer: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerController',
                service: 'soccerMajorMinorService'
            },
            soccerLiveNonLive: { // child of soccer
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerLiveNonLiveController',
                service: 'soccerMajorMinorService'
            },
            soccerBetType: { // child of soccer
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerBetTypeController',
                service: 'soccerBetTypeService'
            },
            soccerLiveBetType: { // child of soccerLiveNonLive
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerLiveBetTypeController',
                service: 'soccerBetTypeService'
            },
            soccerNonLiveBetType: { // child of soccerLiveNonLive
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerNonLiveBetTypeController',
                service: 'soccerBetTypeService'
            }
        },
        'Metric Gaming - Superlive': {
            product: 'liveNonLive',
            liveNonLive: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'MetricGamingLiveNonLiveController',
                service: 'metricGamingLiveNonLiveService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeLiveController',
                service: 'metricGamingBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MetricGamingMatchDetailController',
                service: 'metricGamingMatchDetailService'
            }
        },
        'Other Sports': {
            product: 'liveNonLive',
            liveNonLive: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'OtherSportsLiveNonLiveController',
                service: 'otherSportsLiveNonLiveService'
            },
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeLiveController',
                service: 'sportTypeLiveService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeLiveController',
                service: 'betTypeLiveService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameMatchDetailController',
                service: 'numberGameMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController',
                service: 'numberGameSiteService'
            }
        },
        'Number Game': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'NumberGameBetTypeController',
                service: 'numberGameBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameMatchDetailController',
                service: 'numberGameMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController',
                service: 'numberGameSiteService'
            }
        },
        'Virtual Sports': {
            product: 'sportType',
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'sportTypeService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: function (data) {
                    return data.sportType >= 181 && data.sportType <= 185 ? 'virtualSportsRacingDetailService' : 'virtualSportsSportsbookDetailService';
                }
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Cockfighting': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: 'matchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Colossus Bets': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Live Casino': {
            product: 'thirdPartyProduct',
            thirdPartyProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ThirdPartyProductController',
                service: 'thirdPartyProductService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'thirdPartyBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Casino': {
            product: 'thirdPartyProduct',
            thirdPartyProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ThirdPartyProductController',
                service: 'thirdPartyProductService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'thirdPartyBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Racing': {
            product: 'sportType',
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'sportTypeService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: 'matchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Keno': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Bettrade': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Bingo': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        }
    };

    angular
        .module('app.companyWinlossApp')
        .constant('templateSetting', templateSetting);
})(angular);