import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('filterService', filterService);

    filterService.$inject = ['$http', 'httpResponseService'];
    function filterService($http, httpResponseService) {
        var service = {
            getCurrencies: getCurrencies
        };
        return service;

        function getCurrencies() {
            var url = 'app/ng2-statistic/filter/currencies.json';
            return $http.get(url, {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);