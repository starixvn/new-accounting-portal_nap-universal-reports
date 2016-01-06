/**
 * @ngdoc function
 * @name companyWinlossApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the companyWinlossApp
 */
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('FilterCtrl', FilterController);

    FilterController.$inject = ['settings'];

    function FilterController(settings) {
        /*jshint validthis: true */
        var vm = this;

        vm.date = settings.today;
        vm.disableExport = true;
        vm.disableExpand = true;
        vm.generate = function () {
            vm.disableExport = false;
            vm.disableExpand = false;
        };

        vm.todayClicked = function () {
            vm.date = settings.today;
            vm.generate();
        };

        vm.yesterdayClicked = function () {
            vm.date = settings.yesterday;
            vm.generate();
        };
    }
})();