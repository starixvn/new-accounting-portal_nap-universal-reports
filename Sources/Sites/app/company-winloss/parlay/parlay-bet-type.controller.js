(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ParlayBetTypeController', ParlayBetTypeController);

    ParlayBetTypeController.$inject = ['$scope', '$element', 'fanexGridService'];
    function ParlayBetTypeController($scope, $element, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
    }


})(angular);