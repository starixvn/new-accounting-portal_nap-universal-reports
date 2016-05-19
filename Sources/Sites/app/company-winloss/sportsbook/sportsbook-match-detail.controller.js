(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportsbookMatchDetailController', SportsbookMatchDetailController);

    SportsbookMatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', '$uibModal', '$uibModalStack'];
    function SportsbookMatchDetailController($scope, $element, fanexGridService, showHideColumnService, $uibModal, $uibModalStack) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        showHideColumnBuilder.updateOptions({ hiddenColumns: [4, 5] });
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.viewMatchInformation = viewMatchInformation;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function viewMatchInformation(sportType, matchId, eventDate, leagueName) {
            pane.data.sportType = sportType;
            pane.data.matchId = matchId;
            pane.data.eventDate = eventDate;
            pane.service.getMatchInformation(pane.data).then(function (data) {
                showPopup(data, leagueName);
            });
        }

        function showPopup(data, leagueName) {
            var traderName = data && data.TraderName && data.TraderName != '' ? data.TraderName : "Unassigned";
            var newScope = $scope.$new();
            angular.extend(newScope, {
                sportTypeName: pane.data.sportTypeName,
                betTypeName: pane.data.betTypeName,
                leagueName: leagueName,
                traderName: traderName,
                liveName: pane.data.isLive ? "Live!" : "Non-Live!",
                matchInformation: data.MatchInformation,
                closePopup: closePopup
            });
            $uibModal.open({
                templateUrl: 'app/company-winloss/sportsbook/sportsbook-match-information.html',
                size: 'match-information',
                scope: newScope
            });
        }
        function closePopup() {
            $uibModalStack.dismissAll("Close");
        }
        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var bodyRow = data.bodyRows[i];
                var customAttr = bodyRow.Columns[0].CustomAttr;
                if (customAttr) {
                    var matchName = bodyRow.Columns[0].Value;
                    bodyRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMatchInformation(' + customAttr + ')">' + matchName + '</a>';
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.showPager = true;
            data.pagerOption = {
                itemsPerPage: 50,
                currentPage: 0,
                itemsPerPageArray: [50, 100, 200, 500],
                totalItem: data.bodyRows.length
            };
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);