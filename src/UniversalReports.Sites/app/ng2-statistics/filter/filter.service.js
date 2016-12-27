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
            var url = 'api/ng2-statistics/filter/currencies';
            return $http.post(url, {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getSports() {
            var url = 'api/ng2-statistics/filter/sports';
            return $http.post(url, {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);