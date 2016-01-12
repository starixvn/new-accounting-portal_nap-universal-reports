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
      .config(config);

    function config($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/main.html',
                controller: 'MainCtrl',
                controllerAs: 'main'
            })
            .when('/about', {
                templateUrl: 'views/about.html',
                controller: 'AboutCtrl',
                controllerAs: 'about'
            })
            .otherwise({
                redirectTo: '/'
            });
    }
})();