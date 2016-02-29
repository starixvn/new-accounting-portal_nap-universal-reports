(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('cockfightingDetailService', cockfightingDetailService);

    cockfightingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function cockfightingDetailService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/match-detail', data)
                 .then(httpResponseService.getDataComplete)
                 .catch(httpResponseService.getDataFailed);
        }
    }
})();