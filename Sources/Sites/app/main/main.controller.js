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
        .controller('MainController', MainController);

    MainController.$inject = ['config'];

    function MainController(config) {
        /*jshint validthis: true */
        var vm = this;

        vm.normalMode = true;
        vm.today = config.today;
        vm.yesterday = config.yesterday;
        vm.date = config.today;
        vm.fromDate = moment.utc(config.today).startOf('month').toDate();
        vm.toDate = config.today;
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