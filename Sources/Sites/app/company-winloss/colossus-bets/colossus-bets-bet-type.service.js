(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('colossusBetsBetTypeService', colossusBetsBetTypeService);

    colossusBetsBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper', 'breadcrumbHelper'];
    function colossusBetsBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper, breadcrumbHelper) {
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
            return $http.post('/api/company-win-loss/colossus-bets/bet-type', data)
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

            return $http.post('/api/company-win-loss/colossus-bets/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();