(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('dataService', dataService);

    dataService.$inject = ['$http'];
    function dataService($http) {
        var service = {
            getDataNormal: getDataNormal,
            getDataHistory: getDataHistory
        };
        return service;

        function getDataNormal(date) {
            return $http.get('/api/companywinloss/normal')
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataHistory(fromDate, toDate) {
            return $http.get('/api/companywinloss/history')
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            return response.data;
        }

        function getDataFailed(error) {
            alert('XHR Failed. ' + error.data);
        }
    }
})();