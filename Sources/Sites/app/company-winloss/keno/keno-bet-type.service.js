(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('kenoBetTypeService', kenoBetTypeService);

    kenoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper'];
    function kenoBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper) {
        var service = {
            getData: getData,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite,
            exportExcel: exportExcel
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/keno/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(gridOptions) {
            $http.post('/api/company-win-loss/live-casino/export-bet-type', gridOptions, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, 'test.xls');
                }).catch(httpResponseService.getDataFailed);
        }
    }
})();