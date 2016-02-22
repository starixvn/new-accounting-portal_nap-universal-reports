(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameService', numberGameService);

    numberGameService.$inject = ['$http', 'logger', 'companyWinlossService'];
    function numberGameService($http, logger, companyWinlossService) {
        var service = {
            getBetType: getBetType,
            getMatchDetail: getMatchDetail
        };

        return service;

        function getBetType() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/number-game/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getMatchDetail() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
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