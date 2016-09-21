import angular from "angular";
import numeral from "numeral";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('DailyController', DailyController);

    DailyController.$inject = ['$element', '$scope', 'fanexGridService'];
    function DailyController($element, $scope, fanexGridService) {
        console.log("DailyController");

        $scope.generate = generate;

        function generate() {
            console.log("DailyController-generate");
        }
    }
})(angular);