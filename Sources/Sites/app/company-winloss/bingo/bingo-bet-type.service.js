(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('bingoBetTypeService', bingoBetTypeService);

    bingoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper', 'breadcrumbHelper'];
    function bingoBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/bingo/bet-type', data)
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

            return $http.post('/api/company-win-loss/bingo/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, 'test.xls');
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();