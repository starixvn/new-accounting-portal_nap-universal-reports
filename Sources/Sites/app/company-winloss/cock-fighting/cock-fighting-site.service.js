(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('cockFightingSiteService', kenoSiteService);

    kenoSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function cockFightingSiteService($http, httpResponseService, companyWinlossService) {
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
            return $http.post('/api/company-win-loss/keno/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }       
    }
})();