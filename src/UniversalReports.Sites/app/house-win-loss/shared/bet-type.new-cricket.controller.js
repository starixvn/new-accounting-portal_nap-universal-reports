import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .controller('BetTypeNewCricketController', BetTypeNewCricketController);

    BetTypeNewCricketController.$inject = ['$scope', '$controller', '$element', 'houseWinlossService', 'fanexGridService', 'showHideColumnService'];
    function BetTypeNewCricketController($scope, $controller, $element, houseWinlossService, fanexGridService, showHideColumnService) {

        angular.extend(this, $controller('BetTypeController', {
            $scope: $scope,
            $element: $element,
            houseWinlossService: houseWinlossService,
            fanexGridService: fanexGridService,
            showHideColumnService: showHideColumnService
        }));

        var pane = $scope.pane;
        var gridElement = $element.find('.freegrid');
        var showHideColumnBuilder = new showHideColumnService(pane);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;

        function generate(viewSetting) {
            $scope.viewSetting = viewSetting;
            pane.service.getData(viewSetting, pane.data).then(function (data) {

                showHideColumnBuilder.build(gridElement, data);

                var canViewMatchDetail = pane.data.endDate.diff(pane.data.startDate, 'days') <= 3;
                if (canViewMatchDetail) {
                    $scope.createDrilldownLinks(data.bodyRows);
                    createLinkChargeCom(data.footerRows);
                }

                $scope.renderGrid(data);
                pane.compileAll();
            });
        }

        function createLinkChargeCom(rows) {
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].Columns[0].Value === "Charge Commission") {
                    $scope.createDrilldownLink(rows[i]);
                }
            }
        }
    }
})(angular);