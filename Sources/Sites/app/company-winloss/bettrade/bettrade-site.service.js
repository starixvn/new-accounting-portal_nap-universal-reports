(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('bettradeSiteService', bettradeSiteService);

    bettradeSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function bettradeSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/bettrade/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                betType: gridModel.betType,
                site: gridModel.site
            };

            return $http.post('/api/company-win-loss/bettrade/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, 'test.xls');
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();