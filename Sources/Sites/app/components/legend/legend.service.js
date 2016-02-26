(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('legendService', legendService);

    legendService.$inject = ['$http', 'httpResponseService'];
    function legendService($http, httpResponseService) {
        var service = {
            getData: getData
        };
        return service;

        function getData(legend) {
            return $http.post('api/application/legend', {
                legend: legend
            })
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();