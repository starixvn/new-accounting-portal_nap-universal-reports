(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .constant('levels', {
            MAIN: 1,
            PRODUCT: 2,
            SUB_PRODUCT: 3,
            SPORT_TYPE: 4,
            BET_TYPE: 5,
            SITE: 6
        })
        .constant('levelSettings', {
            'Number Game': {
                product: {
                    templateUrl: 'app/company-winloss/number-game/number-game.html',
                    controller: 'NumberGameController'
                },
                betType: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'NumberGameBetTypeController'
                },
                site: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'NumberGameSiteController'
                }
            },
            'Live Casino': {
                product: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'LiveCasinoController'
                }
            },
            'Virtual Sports': {
                product: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'VirtualSportsController'
                },
                sportType: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'VirtualSportsSportTypeController'
                },
                betType: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'VirtualSportsBetTypeController'
                },
                site: {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'VirtualSportsSiteController'
                }
            }
        });
})();