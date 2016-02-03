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
        });
})();