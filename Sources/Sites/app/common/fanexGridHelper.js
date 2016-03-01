(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('fanexGridHelper', fanexGridHelper);

    fanexGridHelper.$inject = [];
    function fanexGridHelper() {
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