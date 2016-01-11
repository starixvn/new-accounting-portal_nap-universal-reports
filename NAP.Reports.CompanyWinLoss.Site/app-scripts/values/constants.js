(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .constant('settings', {
            today: new Date(2016, 0, 5),
            yesterday: new Date(2016, 0, 4)
        });
})();