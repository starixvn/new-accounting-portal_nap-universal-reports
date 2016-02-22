(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('racingBetTypeService', racingBetTypeService);

    racingBetTypeService.$inject = ['$http', 'logger', 'levels', 'companyWinlossService'];
    function racingBetTypeService($http, logger, levels, companyWinlossService) {
        var service = {
            getData: getData,
            createLinks: createLinks,
            generateSite: generateSite,
            generateDetail: generateDetail,
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType
            };
            return $http.post('/api/company-win-loss/racing/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);

            function getDataComplete(response) {
                logger.hide();
                return response.data;
            }

            function getDataFailed(error) {
                logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
            }
        }

        function createLinks(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-ng-click="generateDetail(' + betTypeId + ',\'' + betTypeName + '\')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-ng-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'' + siteName + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        }
    }
})();
