(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('liveCasinoThirdPartyProductService', liveCasinoThirdPartyProductService);

    liveCasinoThirdPartyProductService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'levels', 'breadcrumbHelper'];
    function liveCasinoThirdPartyProductService($http, httpResponseService, companyWinlossService, levels, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            generateBetType: generateBetType,
            createLinks: createLinks
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/live-casino/third-party-product', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/live-casino/third-party-product/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function generateBetType(thirdPartyProductId, thirdPartyProductName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                thirdPartyProductId: thirdPartyProductId,
                thirdPartyProductName: thirdPartyProductName
            });
        };

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            }
        }
    }
})();