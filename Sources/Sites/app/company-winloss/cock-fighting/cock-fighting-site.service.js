(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('cockfightingSiteService', cockfightingSiteService);

    cockfightingSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function cockfightingSiteService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/cock-fighting/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();