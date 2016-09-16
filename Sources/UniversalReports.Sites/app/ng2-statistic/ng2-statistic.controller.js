import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.NG2Statistic')
        .controller('HouseWinlossController', HouseWinlossController);

    HouseWinlossController.$inject = [];
    function HouseWinlossController() {
        var vm = this;
        vm.panes = [];
    }
})(angular);