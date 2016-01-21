(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('fanexGridHelper', fanexGridHelper);

    fanexGridHelper.$inject = ['$window'];
    function fanexGridHelper($window) {
        var gridElement = angular.element('.freegrid');
        var service = {
            calculateExpandHeight: calculateExpandHeight
        };
        return service;

        function calculateExpandHeight(hasTitle) {
            var bonusSpacing = hasTitle ? 25 : 5;
            var gridOffsetTop = gridElement.offset().top;
            return gridOffsetTop + bonusSpacing;
        }
    }
})();