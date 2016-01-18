/**
 * @ngdoc overview
 * @name companyWinlossApp
 * @description
 * # companyWinlossApp
 *
 * Main module of the application.
 */
(function () {
    'use strict';

    angular
        .module('companyWinlossApp', [
            'ngRoute',
            'angularMoment'
        ])
        .constant('moment', moment)
        .config(config);

    config.$injector = ['$routeProvider', '$httpProvider'];
    function config($routeProvider, $httpProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'app/main/main.html',
                controller: 'MainController',
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

        $httpProvider.interceptors.push(loadingInterceptor);
        loadingInterceptor.$injector = ['$q', '$rootScope'];
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
})();