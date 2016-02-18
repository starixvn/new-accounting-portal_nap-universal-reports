(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('kenoService', kenoService);

    kenoService.$inject = ['$http', 'logger'];
    function kenoService($http, logger) {
        var service = {
            getBetType: getBetType,
            getSite: getSite
        };
        return service;

        function getBetType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/keno/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/keno/site', data)
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