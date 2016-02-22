(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('kenoSiteService', kenoSiteService);

    kenoSiteService.$inject = ['$http', 'loggerhttpResponseService', 'companyWinlossService'];
    function kenoSiteService($http, httpResponseService, companyWinlossService) {
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
            return $http.post('/api/company-win-loss/keno/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }       
    }
})();