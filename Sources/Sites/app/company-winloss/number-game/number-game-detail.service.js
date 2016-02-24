(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameDetailService', numberGameDetailService);

    numberGameDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function numberGameDetailService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };

        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();