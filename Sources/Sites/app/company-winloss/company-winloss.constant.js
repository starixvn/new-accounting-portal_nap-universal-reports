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
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SoccerLiveNonLiveController',
                service: 'soccerMajorMinorService'
            },
            soccerBetType: { // child of soccer
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SoccerBetTypeController',
                service: 'soccerBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
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
                controller: 'BetTypeController',
                service: 'sportsbookProductViewBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'metricGamingMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookSiteController',
                service: 'metricGamingSiteService'
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
                controller: 'SportsbookSportTypeController',
                service: 'sportsbookSportTypeService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportsbookSportTypeViewBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
            }
        },
        'Parlay': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ParlayBetTypeController',
                service: 'parlayBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'parlaySiteService'
            }
        },
        'Live Casino': {
            product: 'casinoProduct',
            casinoProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'CasinoProductController',
                service: 'casinoProductService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'CasinoBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Casino': {
            product: 'casinoProduct',
            casinoProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'CasinoProductController',
                service: 'casinoProductService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'CasinoBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
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
                controller: 'MatchDetailController',
                service: 'numberGameMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
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
                service: 'sportTypeViewBetTypeService'
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
                service: 'sportTypeViewBetTypeService'
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
        }
    };
    var universalSettings = {
        products: {
            "Bettrade": 0,
            "Bingo": 7,
            "Keno": 8,
            "Colossus Bets": 15
        },
        settings: {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'universalBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'universalSiteService'
            }
        },
        getProductId: function (productName) {
            return universalSettings.products[productName];
        }
    };
    angular
        .module('app.companyWinlossApp')
        .constant('templateSetting', templateSetting)
        .constant('universalSettings', universalSettings);
})(angular);