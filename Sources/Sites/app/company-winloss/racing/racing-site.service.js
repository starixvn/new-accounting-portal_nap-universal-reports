(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingSiteService', racingSiteService);

    racingSiteService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService'];
    function racingSiteService($http, httpResponseService, levels, companyWinlossService) {
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
            return $http.post('/api/company-win-loss/racing/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
