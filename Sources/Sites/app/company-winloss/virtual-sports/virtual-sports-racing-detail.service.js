(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsRacingDetailService', virtualSportsRacingDetailService);

    virtualSportsRacingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function virtualSportsRacingDetailService($http, httpResponseService, companyWinlossService) {
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
            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();