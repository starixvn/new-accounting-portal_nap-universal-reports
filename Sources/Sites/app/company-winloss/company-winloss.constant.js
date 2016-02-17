(function () {
    'use strict';

    var levels = {
        PRODUCT: 1,
        THIRD_PARTY_PRODUCT: 2,
        SPORT_TYPE: 3,
        BET_TYPE: 4,
        SITE: 5,
        DETAIL: 6
    };

    var levelSettings = {
        'product': {
            templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
            controller: 'ProductController'
        },
        'Number Game': {
            level: levels.BET_TYPE,
            betType: {
                templateUrl: 'app/company-winloss/number-game/number-game.html',
                controller: 'NumberGameBetTypeController'
            },
            detail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameDetailController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController'
            }
        },
        'Virtual Sports': {
            level: levels.SPORT_TYPE,
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSportTypeController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsBetTypeController'
            },
            detail: function (gridModel) {
                if (gridModel.sportType >= 181 && gridModel.sportType <= 185) {
                    return {
                        templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-detail.html',
                        controller: 'VirtualSportsRacingDetailController'
                    }
                } else {
                    return {
                        templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-detail.html',
                        controller: 'VirtualSportsSportsbookDetailController'
                    }
                }
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSiteController'
            }
        },
        'Racing': {
            level: levels.SPORT_TYPE,
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSportTypeController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingBetTypeController'
            },
            detail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingDetailController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSiteController'
            }
        },
        'Keno': {
            level: levels.BET_TYPE,
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoBetTypeController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoSiteController'
            }
        },
        'Live Casino': {
            level: levels.THIRD_PARTY_PRODUCT,
            thirdPartyProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'LiveCasinoThirdPartyProductController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'LiveCasinoBetTypeController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'LiveCasinoSiteController'
            }
        }
    };

    angular
        .module('companyWinlossApp')
        .constant('levels', levels)
        .constant('levelSettings', levelSettings);
})();