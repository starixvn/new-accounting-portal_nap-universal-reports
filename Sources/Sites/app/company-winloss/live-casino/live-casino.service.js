(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('liveCasinoService', liveCasinoService);

    liveCasinoService.$inject = ['$http', 'logger'];
    function liveCasinoService($http, logger) {
        var service = {
            getThirdPartyProduct: getThirdPartyProduct,
            getBetType: getBetType,
            getSite: getSite
        };
        return service;

        function getThirdPartyProduct(startDate, endDate, breadCumb) {
            var data = { startDate: startDate, endDate: endDate, breadCumb: breadCumb };
            return $http.post('/api/company-win-loss/live-casino/third-party-product', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, productId, breadCumb) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                productId: productId,
                breadCumb: breadCumb
            };
            return $http.post('/api/company-win-loss/live-casino/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, betType, site, breadCumb) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                betType: betType,
                site: site,
                breadCumb: breadCumb
            };
            return $http.post('/api/company-win-loss/live-casino/site', data)
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