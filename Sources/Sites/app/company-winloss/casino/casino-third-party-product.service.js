(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('casinoThirdPartyProductService', casinoThirdPartyProductService);

    casinoThirdPartyProductService.$inject = ['$http', 'logger', 'companyWinlossService'];
    function casinoThirdPartyProductService($http, logger, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/casino/third-party-product', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }
       
        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();