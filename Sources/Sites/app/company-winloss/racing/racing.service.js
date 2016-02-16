(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('racingService', racingService);

    racingService.$inject = ['$http', 'logger'];
    function racingService($http, logger) {
        var service = {
            getSportType: getSportType,
            getBetType: getBetType,
            getGameDetail: getGameDetail,
            getSite: getSite
        };
        return service;

        function getSportType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/racing/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, sportType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType
            };
            return $http.post('/api/company-win-loss/racing/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getGameDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/racing/match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, sportType, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/racing/site', data)
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