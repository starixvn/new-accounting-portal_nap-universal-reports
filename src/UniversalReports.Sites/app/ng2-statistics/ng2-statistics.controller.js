import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.ng2StatisticsApp')
        .controller('NG2StatisticsController', NG2StatisticsController);

    NG2StatisticsController.$inject = [];
    function NG2StatisticsController() {
        var vm = this;
        vm.xxx=10;
        vm.panes = [];
    }
})(angular);