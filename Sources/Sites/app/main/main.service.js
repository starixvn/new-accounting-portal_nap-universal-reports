(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('dataService', dataService);

    dataService.$inject = ['$http', 'logger'];
    function dataService($http, logger) {
        var service = {
            getDataNormal: getDataNormal,
            getDataHistory: getDataHistory
        };
        return service;

        function getDataNormal(date) {
            return $http.get('/index2.html')
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataHistory(fromDate, toDate) {
            return $http.get('/index2.html')
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.')
        }
    }
})();