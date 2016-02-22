(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('kenoBetTypeService', kenoBetTypeService);

    kenoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper'];
    function kenoBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper) {
        var service = {
            getData: getData,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/keno/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }   
    }
})();