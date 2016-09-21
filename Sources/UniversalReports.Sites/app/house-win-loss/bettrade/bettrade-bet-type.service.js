import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('bettradeBetTypeService', bettradeBetTypeService);

    bettradeBetTypeService.$inject = ['$http', 'httpResponseService', 'betTypeService', 'titleService'];
    function bettradeBetTypeService($http, httpResponseService, betTypeService, titleService) {
        
        var service = {
            getTitle: titleService.getProductTitle,
            getData: betTypeService.getData,
            exportExcel: betTypeService.exportExcel
        };
        return service;
    }
})(angular);