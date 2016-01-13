(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .constant('config', (function () {
            var today = moment.utc();
            var yesterday = moment.utc().subtract(1, 'days');
            return {
                today: today.toDate(),
                yesterday: yesterday.toDate()
            }
        })());

})();