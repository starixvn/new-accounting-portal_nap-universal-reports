(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('bettradeSiteService', bettradeSiteService);

    bettradeSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function bettradeSiteService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/bettrade/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();