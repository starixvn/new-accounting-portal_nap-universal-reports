(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ProductViewBetTypeLiveController', ProductViewBetTypeLiveController);

    ProductViewBetTypeLiveController.$inject = ['$scope', '$controller'];
    function ProductViewBetTypeLiveController($scope, $controller) {
        var pane = $scope.pane;
        pane.getTitle = getTitle;
        function getTitle(isLast) {
            return isLast ? pane.data.productName + ' Product Win/Loss Report' : pane.data.productName;
        }

        $controller('BetTypeLiveController', { $scope: $scope });
    }
})(angular);