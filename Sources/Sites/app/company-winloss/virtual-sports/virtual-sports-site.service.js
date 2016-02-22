(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsSiteService', virtualSportsSiteService);

    virtualSportsSiteService.$inject = ['$http', 'logger', 'levels', 'companyWinlossService'];
    function virtualSportsSiteService($http, logger, levels, companyWinlossService) {
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
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/virtual-sports/site', data)
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
