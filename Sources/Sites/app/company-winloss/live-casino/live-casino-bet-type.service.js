(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('liveCasinoBetTypeService', liveCasinoBetTypeService);

    liveCasinoBetTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService'];
    function liveCasinoBetTypeService($http, httpResponseService, levels, companyWinlossService) {
        var service = {
            getData: getData,
            createLinks: createLinks,
            generateSite: generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate, productId: gridModel.thirdPartyProductId };
            return $http.post('/api/company-win-loss/live-casino/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
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