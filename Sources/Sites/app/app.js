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
            'ngRoute'
        ])
        .constant('moment', moment)
        .config(config);

    function config($routeProvider) {
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
    }
})();