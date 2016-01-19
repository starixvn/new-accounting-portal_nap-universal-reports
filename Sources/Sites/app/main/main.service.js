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
            var data = { startdate: date, enddate: date };
            return $http.post('/api/productwinloss/values', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataHistory(startdate, enddate) {
            var data = { startdate: startdate, enddate: enddate };
            return $http.post('/api/productwinloss/values', data)
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