(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('FilterController', FilterController);

    FilterController.$inject = ['$compile', '$scope', 'config'];
    function FilterController($compile, $scope, config) {
        /*jshint validthis: true */
        var vm = this;
        vm.currentLevel = 0;
        vm.normalMode = true;
        vm.today = config.today;
        vm.yesterday = config.yesterday;
        vm.date = config.today;
        vm.startDate = moment.utc(config.today).startOf('month');
        vm.endDate = config.today;

        vm.todayClicked = function () {
            vm.date = vm.today;
            vm.generate();
        };

        vm.yesterdayClicked = function () {
            vm.date = vm.yesterday;
            vm.generate();
        };

        vm.viewHistoryMode = function () {
            vm.normalMode = false;
        };

        vm.viewNormalMode = function () {
            vm.normalMode = true;
        };

        vm.getEndOfDay = function (date) {
            return moment.utc(date).endOf('day');
        };
    }
})();