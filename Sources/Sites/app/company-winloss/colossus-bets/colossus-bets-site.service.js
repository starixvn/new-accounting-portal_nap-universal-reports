(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('colossusBetsSiteService', colossusBetsSiteService);

    colossusBetsSiteService.$inject = ['$http', 'logger', 'companyWinlossService'];
    function colossusBetsSiteService($http, logger, companyWinlossService) {
        var service = {
            getData: getData
        };
        return service;
       
        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/colossus-bets/site', data)
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