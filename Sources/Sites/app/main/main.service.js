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
            return getData(date, date);
        }

        function getDataHistory(startDate, endDate) {
            return getData(startDate, endDate);
        }

        function getData(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
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