(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoController', LiveCasinoController);

    LiveCasinoController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'dataService', 'fanexGridHelper', 'levels', 'companyWinlossService'];
    function LiveCasinoController($compile, $scope, $element, formatStrings, dataService, fanexGridHelper, levels, companyWinlossService) {
        $scope.generate = generate;

        function generate() {
            $element.html('test');
        }
    }
})();