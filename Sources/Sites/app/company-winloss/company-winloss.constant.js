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
        'Product': {
            templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
            controller: 'ProductController'
        },
        'Number Game': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/number-game/number-game.html',
                controller: 'NumberGameBetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController'
            }]
        },
        'Virtual Sports': {
            templates: [{
                level: levels.SPORT_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSportTypeController'
            },
            {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsBetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-detail.html',
                controller: function (gridModel) {
                    return gridModel.sportType >= 181 && gridModel.sportType <= 185 ? 'VirtualSportsRacingDetailController' : 'VirtualSportsSportsbookDetailController'
                }
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSiteController'
            }]
        },
        'Racing': {
            templates: [{
                level: levels.SPORT_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSportTypeController'
            },
            {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingBetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSiteController'
            }]
        },
        'Keno': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoBetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoSiteController'
            }]
        },
        'Live Casino': {
            templates: [{
                level: levels.THIRD_PARTY_PRODUCT,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'LiveCasinoThirdPartyProductController'
            }, {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'LiveCasinoBetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'LiveCasinoSiteController'
            }]
        }
    };

    angular
        .module('companyWinlossApp')
        .constant('levels', levels)
        .constant('levelSettings', levelSettings);
})();