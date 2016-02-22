(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('casinoThirdPartyProductService', casinoThirdPartyProductService);

    casinoThirdPartyProductService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function casinoThirdPartyProductService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/casino/third-party-product', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }       
    }
})();