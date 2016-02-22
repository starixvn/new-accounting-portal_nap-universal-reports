(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsSiteService', virtualSportsSiteService);

    virtualSportsSiteService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService'];
    function virtualSportsSiteService($http, httpResponseService, levels, companyWinlossService) {
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
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/virtual-sports/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
