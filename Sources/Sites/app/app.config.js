(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .config(config);

    config.$inject = ['$routeProvider', '$httpProvider', 'config'];
    function config($routeProvider, $httpProvider, config) {
        configRouting();
        configHttp();

        function configRouting() {
            $routeProvider
                .when('/', {
                    templateUrl: 'app/company-winloss/company-winloss.html',
                    controller: 'CompanyWinlossController',
                    controllerAs: 'vm'
                })
                .when('/about', {
                    templateUrl: 'app/about/about.html',
                    controller: 'AboutController',
                    controllerAs: 'vm'
                })
                .otherwise({
                    redirectTo: '/'
                });
        }

        function configHttp() {
            $httpProvider.interceptors.push(templateInterceptor);
            function templateInterceptor() {
                return {
                    request: function (c) {
                        var url = c.url;
                        var subString = url.substring(0, 4);
                        if (subString.toLowerCase() !== 'http') {
                            c.url = config.rootUrl + '/' + url;
                        }

                        return c;
                    }
                }
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