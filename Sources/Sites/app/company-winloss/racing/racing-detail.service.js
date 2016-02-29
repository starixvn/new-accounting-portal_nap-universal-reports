(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingDetailService', racingDetailService);

    racingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function racingDetailService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/racing/match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

    }
})();