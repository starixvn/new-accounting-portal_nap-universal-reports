(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsRacingDetailService', virtualSportsRacingDetailService);

    virtualSportsRacingDetailService.$inject = ['$http', 'logger', 'companyWinlossService'];
    function virtualSportsRacingDetailService($http, logger, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
            function getDataComplete(response) {
                logger.hide();
                return response.data;
            }

            function getDataFailed(error) {
                logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
            }
        }
    }
})();