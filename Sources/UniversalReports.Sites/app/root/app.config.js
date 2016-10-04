import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .config(config);

    config.$inject = ['$httpProvider', 'config'];
    function config($httpProvider, config) {
        configHttp();

        function configHttp() {
            $httpProvider.interceptors.push(templateInterceptor);
            templateInterceptor.$inject = ['$templateCache'];
            function templateInterceptor($templateCache) {
                return {
                    request: function (c) {
                        var url = c.url;
                        if ($templateCache.get(url) === undefined) {
                            var subString = url.substring(0, 4);
                            if (subString.toLowerCase() !== 'http') {
                                c.url = config.rootUrl + '/' + url + "?version=20161004";
                            }
                        }

                        return c;
                    }
                };
            }

            $httpProvider.interceptors.push(loadingInterceptor);
            loadingInterceptor.$inject = ['$q', '$rootScope'];
            function loadingInterceptor($q, $rootScope) {
                return {
                    request: function (config) {
                        $rootScope.$broadcast('loading-started');
                        return config || $q.when(config);
                    },
                    response: function (response) {
                        $rootScope.$broadcast('loading-complete');
                        return response || $q.when(response);
                    }, responseError: function (response) {
                        $rootScope.$broadcast('loading-complete');
                        return $q.reject(response);
                    }
                };
            }
        }
    }
})(angular);