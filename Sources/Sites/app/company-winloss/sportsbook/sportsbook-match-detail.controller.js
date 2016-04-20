(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportsbookMatchDetailController', SportsbookMatchDetailController);

    SportsbookMatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', '$uibModal'];
    function SportsbookMatchDetailController($scope, $element, fanexGridService, showHideColumnService, $uibModal) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.viewMatchInformation = viewMatchInformation;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnService.build($scope, gridElement, data, { hiddenColumns: [4, 5] });
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function viewMatchInformation(matchId, leagueName) {
            pane.data.matchId = matchId;
            showPopup(null, leagueName); return;
            pane.service.getMatchInformation(pane.data).then(function (data) {
            });
        }

        function showPopup(data, leagueName) {
            data = { "TraderName": "", "MatchInformation": "<div>Test</div>" };
            var traderName = data && data.TraderName && data.TraderName != '' ? data.TraderName : "Unassigned";
            var newScope = $scope.$new();
            angular.extend(newScope, {
                sportTypeName: pane.data.sportTypeName,
                leagueName: leagueName,
                traderName: traderName,
                matchInformation: data.MatchInformation
            });
            $uibModal.open({
                templateUrl: 'app/company-winloss/sportsbook/sportsbook-match-information.html',
                scope: newScope
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var bodyRow = data.bodyRows[i];
                var matchId = bodyRow.Columns[0].CustomAttr;
                if (matchId) {
                    var matchName = bodyRow.Columns[0].Value;
                    bodyRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMatchInformation(\'' + matchId + '\')">' + matchName + '</a>';
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnService.customButtonHtml
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);