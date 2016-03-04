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
                controller: 'SportTypeController'
            },
            {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
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
                controller: 'SiteController'
            }]
        },
        'Live Casino': {
            templates: [{
                level: levels.THIRD_PARTY_PRODUCT,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ThirdPartyProductController'
            }, {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Casino': {
            templates: [{
                level: levels.THIRD_PARTY_PRODUCT,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ThirdPartyProductController'
            }, {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Racing': {
            templates: [{
                level: levels.SPORT_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-sport-type.html',
                controller: 'SportTypeController'
            },
            {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Keno': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Bettrade': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
                {
                    level: levels.SITE,
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'SiteController'
                }]
        },
        'Bingo': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Colossus Bets': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Cockfighting': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-sport-type.html',
                controller: 'CockfightingDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
    };

    angular
        .module('app.companyWinlossApp')
        .constant('levels', levels)
        .constant('levelSettings', levelSettings);
})();