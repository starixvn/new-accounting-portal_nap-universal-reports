(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('legendService', legendService);

    legendService.$inject = ['$http', 'httpResponseService', 'config'];
    function legendService($http, httpResponseService, config) {
        var service = {
            getData: getData
        };
        return service;

        function getData(menuId) {
            var url = config.legacyPath + '/LegendManagement/LegendManagement/GetReportLegend';
            return $http.post(url, {
                menuId: menuId
            }).then(httpResponseService.getDataComplete);
        }
    }
})(angular);