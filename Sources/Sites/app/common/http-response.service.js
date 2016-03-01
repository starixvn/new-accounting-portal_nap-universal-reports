(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('httpResponseService', httpResponseService);

    httpResponseService.$inject = ['logger'];
    function httpResponseService(logger) {
        var cachedData;
        var service = {
            getDataComplete: getDataComplete,
            getDataFailed: getDataFailed,
            getCachedData: getCachedData
        };

        return service;

        function getDataComplete(response) {
            logger.hide();
            cachedData = response.data;
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }

        function getCachedData() {
            return cachedData;
        }
    }
})();