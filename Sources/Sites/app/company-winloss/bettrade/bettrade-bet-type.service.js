(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('bettradeBetTypeService', bettradeBetTypeService);

    bettradeBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper'];
    function bettradeBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper) {
        var service = {
            getData: getData,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/bettrade/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})();