(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameService', numberGameService);

    numberGameService.$inject = ['$http', 'logger'];
    function numberGameService($http, logger) {
        var service = {
            getSummary: getSummary,
            getMatchDetail: getMatchDetail,
            getSite: getSite
        };
        return service;

        function getSummary(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/number-game/summary', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getMatchDetail(startDate, endDate, isLive, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: 161,
                isLive: isLive,
                betType: betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, isLive, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: 161,
                isLive: isLive,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/number-game/site', data)
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