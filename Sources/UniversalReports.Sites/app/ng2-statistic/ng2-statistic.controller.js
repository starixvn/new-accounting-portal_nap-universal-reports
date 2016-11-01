import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('NG2StatisticController', NG2StatisticController);

    NG2StatisticController.$inject = [];
    function NG2StatisticController() {
        var vm = this;
        vm.panes = [];
    }
})(angular);