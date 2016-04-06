(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsBetTypeService', otherSportsBetTypeService);

    otherSportsBetTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function otherSportsBetTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
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
            return $http.post('api/company-win-loss/other-sports/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType
            };

            return $http.post('api/company-win-loss/other-sports/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function createLinks(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
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