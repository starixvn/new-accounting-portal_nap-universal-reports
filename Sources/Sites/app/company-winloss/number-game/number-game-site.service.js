(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameSiteService', numberGameSiteService);

    numberGameSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function numberGameSiteService($http, httpResponseService, companyWinlossService) {
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
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/number-game/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();