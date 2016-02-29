(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('logger', logger);

    logger.$inject = ['$rootScope'];
    function logger($rootScope) {
        var service = {
            log: log,
            hide: hide,
            logError: logError,
            logSuccess: logSuccess,
            logWarning: logWarning
        };
        return service;

        function hide() {
            $rootScope.$broadcast('alert-hide');
        }

        function log(message) {
            logIt(message, source, 'info');
        }

        function logWarning(message) {
            logIt(message, 'warning');
        }

        function logSuccess(message) {
            logIt(message, 'success');
        }

        function logError(message) {
            logIt(message, 'error');
        }

        function logIt(message, type) {
            if (type === 'error') {
                $rootScope.$broadcast('alert-show', message);
            }
        }
    }
})();