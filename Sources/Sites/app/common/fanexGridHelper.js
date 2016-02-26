(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('fanexGridHelper', fanexGridHelper);

    fanexGridHelper.$inject = [];
    function fanexGridHelper() {
        var service = {
            calculateExpandHeight: calculateExpandHeight,
            highlightFooterColumns: highlightFooterColumns
        };
        return service;

        function calculateExpandHeight(gridElement, hasTitle) {
            var bonusSpacing = hasTitle ? 25 : 5;
            var gridOffsetTop = gridElement.offset().top;
            return gridOffsetTop + bonusSpacing;
        }

        function highlightFooterColumns(gridOption, columnIndexes) {
            if (angular.isUndefined(columnIndexes)) {
                columnIndexes = [4];
            }

            if (gridOption.footerRows && gridOption.footerRows.length > 0) {
                for (var i = 0; i < columnIndexes.length; i++) {
                    var columnIndex = columnIndexes[i];
                    gridOption.footerRows[0].Columns[columnIndex].TdClass = 'highlight-column';
                }
            }
        }
    }
})();