(function (angular) {
    'use strict';

    var templateSetting = {
        'Number Game': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/number-game/number-game.html',
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
                    return data.sportType >= 181 && data.sportType <= 185 ? 'virtualSportsRacingDetailService' : 'virtualSportsSportsbookDetailService'
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