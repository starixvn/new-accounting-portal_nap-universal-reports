(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('cockfightingBetTypeService', cockfightingBetTypeService);

    cockfightingBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function cockFightingBetTypeService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData,
            createLinks: createSiteLinks,
            generateMatchDetail: generateMatchDetail,
            generateSite: generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/cock-fighting/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function createSiteLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                data.bodyRows[i].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateDetail()">' + betTypeName + '</a>';
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite()">' + siteName + '</a>';
                }
            }
        }

        function generateDetail() {
            companyWinlossService.generate({
                level: levels.DETAIL
            });
        }

        function generateSite() {
            companyWinlossService.generate({
                level: levels.SITE
            });
        }
    }
})();