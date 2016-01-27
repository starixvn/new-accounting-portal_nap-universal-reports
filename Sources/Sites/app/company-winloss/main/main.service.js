(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('dataService', dataService);

    dataService.$inject = ['$http', 'logger'];
    function dataService($http, logger) {
        var service = {
            getData: getData
        };
        return service;

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