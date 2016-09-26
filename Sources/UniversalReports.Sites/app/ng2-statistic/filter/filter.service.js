import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('filterService', filterService);

    filterService.$inject = ['$http', 'httpResponseService'];
    function filterService($http, httpResponseService) {
        var service = {
            getCurrencies: getCurrencies,
            getSports: getSports
        };
        return service;

        function getCurrencies() {
            var url = 'app/ng2-statistic/filter/currencies.json';
            //var url = 'api/ng2-statistic/filter/currencies';
            return $http.get(url, {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getSports() {
            var url = 'api/ng2-statistic/filter/sports';
            return $http.post(url, {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);