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

        vm.normalMode = true;
        vm.today = settings.today;
        vm.yesterday = settings.yesterday;
        vm.date = settings.today;
        vm.disableExport = true;
        vm.disableExpand = true;
        vm.generate = function () {
            vm.disableExport = false;
            vm.disableExpand = false;
            console.log(vm.date);
        };

        vm.viewHistoryMode = function () {
            vm.normalMode = false;
        };

        vm.viewNormalMode = function () {
            vm.normalMode = true;
        };

        vm.todayClicked = function () {
            vm.date = vm.today;
            vm.generate();
        };

        vm.yesterdayClicked = function () {
            vm.date = vm.yesterday;
            vm.generate();
        };
    }
})();