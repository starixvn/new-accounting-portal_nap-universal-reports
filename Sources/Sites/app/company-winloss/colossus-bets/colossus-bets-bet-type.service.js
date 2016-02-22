(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('colossusBetsBetTypeService', colossusBetsBetTypeService);

    colossusBetsBetTypeService.$inject = ['$http', 'logger', 'levels', 'companyWinlossService'];
    function colossusBetsBetTypeService($http, logger, levels, companyWinlossService) {
        var service = {
            getData: getData,
            createLinks: createLinks,
            generateSite: generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/colossus-bets/bet-type', data)
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
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-ng-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'' + siteName + '\')">' + siteName + '</a>';
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
    }
})();