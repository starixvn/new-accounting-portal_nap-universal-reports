(function (angular, undefined) {
	'use strict';

	angular
        .module('app.companyWinlossApp')
        .controller('SoccerController', SoccerController);

	SoccerController.$inject =['$scope', '$element', 'fanexGridService', 'soccerLiveNonLiveService'];
	function SoccerController($scope, $element, fanexGridService, soccerLiveNonLiveService) {
		var pane = $scope.pane;
		var tab = $scope.tab;
		var gridElements = $element.find('.freegrid');
		var majorMinorGridElement = angular.element(gridElements[0]);
		var liveNonLiveGridElement = angular.element(gridElements[1]);
		$scope.generate = generate;
		$scope.generateSoccerLiveNonLivePane = generateSoccerLiveNonLivePane;
		$scope.generateSoccerBetTypePane = generateSoccerBetTypePane;

		pane.data.isLive = 2; // live and nonlive
		
		function getTitleWhenMajorMinor(isLast) {
		    return isLast ?
                pane.data.productName + ' MAJOR/MINOR BET TYPES' :
                pane.data.productName;
		}

	    function getTitleWhenLiveNonLive(isLast) {
	        return isLast ?
                pane.data.productName + ' LIVE/NON-LIVE' :
                pane.data.productName;
	    }

		function generate() {
            var count = 0;
            var compileLinks = function () {
                count++;
                if (count === 2) {
                    pane.compileLinks();
                }
            };

            pane.service.getData(pane.data).then(function (data) {
			    createLinksForMajorMinor(data);
                pane.getTitle = getTitleWhenMajorMinor;
				renderGrid(majorMinorGridElement, data);
				compileLinks();
			});

			soccerLiveNonLiveService.getData(pane.data).then(function (data) {
			    createLinksForLiveNonLive(data);
                pane.getTitle = getTitleWhenLiveNonLive;
				renderGrid(liveNonLiveGridElement, data);
			    compileLinks();
			});
		}

		function renderGrid(gridElement, data) {
			var titleInfo = {
				text: tab.generateBreadcrumbHtml(),
				showCollapseExpandButton: true,
				showExcelButton: false,
				exportExcelFunction: exportExcel
			};

			data.titleInfo = titleInfo;
			data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
			data.defaultCollapseAllGroups = true;
			gridElement.fanexGrid(data);
		}

		function createLinksForMajorMinor(data) {
			for (var i = 0; i < data.bodyRows.length; i++) {
				var betTypeRow = data.bodyRows[i];
				var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
				betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
			}
		}

		function generateSoccerBetTypePane(betTypeNameMajorMinor) {
            var data = {
                betTypeNameMajorMinor: betTypeNameMajorMinor
		    };
            angular.extend(data, pane.data);

            tab.goForward('soccerBetType', data);
        }

        function createLinksForLiveNonLive(data) {
			for (var i = 0; i < data.bodyRows.length; i++) {
				var betTypeRow = data.bodyRows[i];
				var soccerLiveNonLive = betTypeRow.Columns[0].Value;
				betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLivePane(\'' + soccerLiveNonLive + '\')">' + soccerLiveNonLive + '</a>';
			}
        }

        function generateSoccerLiveNonLivePane(soccerLiveNonLive) {
            var data = {
                soccerLiveNonLive: soccerLiveNonLive
		    };
            angular.extend(data, pane.data);

            tab.goForward('soccerLiveNonLive', data);
        }

        function exportExcel() {
            pane.data.isLive = true;
            var liveTitle = tab.generateBreadcrumbText();
            pane.data.isLive = false;
            var noneLiveTitle = tab.generateBreadcrumbText();
            delete (pane.data.isLive);
            pane.service.exportExcel(liveTitle, noneLiveTitle, pane.data, pane.getFileName());
        }
	}
})(angular, undefined);