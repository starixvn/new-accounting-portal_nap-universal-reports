(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('fanexGridHelper', fanexGridHelper);

    fanexGridHelper.$inject = ['$window'];
    function fanexGridHelper($window) {
        var service = {
            calculateExpandHeight: calculateExpandHeight
        };
        return service;

        function calculateExpandHeight(gridElement, hasTitle) {
            var bonusSpacing = hasTitle ? 25 : 5;
            var gridOffsetTop = gridElement.offset().top;
            return gridOffsetTop + bonusSpacing;
        }
    }
})();