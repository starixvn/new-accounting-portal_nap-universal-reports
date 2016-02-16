(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsService', virtualSportsService);

    virtualSportsService.$inject = ['$http', 'logger'];
    function virtualSportsService($http, logger) {
        var service = {
            getSportType: getSportType,
            getBetType: getBetType,
            getGameDetail: getGameDetail,
            getSite: getSite
        };
        return service;

        function getSportType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/virtual-sports/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, sportType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType
            };
            return $http.post('/api/company-win-loss/virtual-sports/bet-type', data)
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
            return $http.post('/api/company-win-loss/virtual-sports/sports-book-match-detail', data)
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
            return $http.post('/api/company-win-loss/virtual-sports/site', data)
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