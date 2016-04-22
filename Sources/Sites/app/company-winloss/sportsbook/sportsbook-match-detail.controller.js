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
            data = { "TraderName": "", "MatchInformation": "\u003ctable class=\"fn-rs popup\"\u003e\u003cthead\u003e\u003ctr class=\"header\"\u003e\u003cth class=\"cl-ko-time\"\u003eKick Off. Time\u003c/th\u003e\u003cth class=\"cl-match\"\u003eMatch\u003c/th\u003e\u003cth class=\"cl-ht-score\"\u003eHT Score\u003c/th\u003e\u003cth class=\"cl-f-score\"\u003eFinal Score\u003c/th\u003e\u003cth class=\"cl-status\"\u003eStatus\u003c/th\u003e\u003c/tr\u003e\u003c/thead\u003e\u003ctbody\u003e\u003ctr class=\"data odd\"\u003e\u003ctd class=\"cl-ko-time\" rowspan=\"2\"\u003e04/13/2016\u003cbr/\u003e01:59:59 PM\u003c/td\u003e\u003ctd class=\"cl-match home \"\u003eWest Ham United \u0026nbsp;\u003cdiv class=\"last-goal\"\u003e\u0026nbsp;\u003c/div\u003e\u003c/td\u003e\u003ctd class=\"cl-ht-score\"\u003e0\u003c/td\u003e\u003ctd class=\"cl-f-score\"\u003e1\u003c/td\u003e\u003ctd rowspan=\"2\" class=\"cl-status \"\u003e\u003cdiv\u003eCompleted\u003c/div\u003e\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data odd\"\u003e\u003ctd class=\"cl-match away \"\u003eManchester United \u0026nbsp;\u003cdiv class=\"first-goal\"\u003e\u0026nbsp;\u003c/div\u003e\u003c/td\u003e\u003ctd class=\"cl-ht-score\"\u003e0\u003c/td\u003e\u003ctd class=\"cl-f-score\"\u003e2\u003c/td\u003e\u003c/tr\u003e\u003c/tbody\u003e\u003c/table\u003e\u003cbr /\u003e\u003ctable class=\"fn-rs popup\"\u003e\u003cthead\u003e\u003ctr class=\"header\"\u003e\u003cth class=\"cl-match\"\u003eMoreResults\u003c/th\u003e\u003cth class=\"cl-result home\"\u003eWest Ham United\u003c/th\u003e\u003cth class=\"cl-result away\"\u003eManchester United\u003c/th\u003e\u003c/tr\u003e\u003c/thead\u003e\u003ctbody\u003e\u003ctr class=\"data\"\u003e\u003ctd colspan=\"3\" class=\"cl-league sub\"\u003eGoals\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eFirst 10 Minutes 1X2\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eDraw\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd colspan=\"3\" class=\"cl-league sub\"\u003eGoal Time\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eFirst Goal Time (10 Min)\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003e51-60 Min\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eFirst Goal Time (15 Min)\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003e46-60 Min\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd colspan=\"3\" class=\"cl-league sub\"\u003eGoal Scorer\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eFirst Goal\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eMarcus Rashford\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eGoal 01\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eJames Tomkins\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd colspan=\"3\" class=\"cl-league sub\"\u003eSpecial\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eExtra Time Yes/No\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eNo\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eExtra Time and Goal\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eNo\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003ePenalty Shootout Yes/No\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eNo\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"data\"\u003e\u003ctd class=\"cl-match\"\u003eMatch Decided Method\u003c/td\u003e\u003ctd class=\"cl-result home\" colspan=\"2\"\u003eManchester United/Regular Time\u003c/td\u003e\u003c/tr\u003e\u003c/tbody\u003e\u003c/table\u003e" };
            var traderName = data && data.TraderName && data.TraderName != '' ? data.TraderName : "Unassigned";
            var newScope = $scope.$new();
            angular.extend(newScope, {
                sportTypeName: pane.data.sportTypeName,
                betTypeName: pane.data.betTypeName,
                leagueName: leagueName,
                traderName: traderName,
                liveName: pane.data.isLive ? "Live!" : "Non-Live!",
                matchInformation: data.MatchInformation
            });
            $uibModal.open({
                templateUrl: 'app/company-winloss/sportsbook/sportsbook-match-information.html',
                size: 'match-information',
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
                customButtons: showHideColumnService.getButtonHtml()
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