(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['templateSetting'];
    function companyWinlossService(templateSetting) {
        var service = {
            getTemplate: getTemplate
        };
        return service;

        function getTemplate(data, type) {
            if (type === 'product') {
                return {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'ProductController',
                    service: 'productService'
                };
            }

            var productSetting = templateSetting[data.productName];
            if (angular.isUndefined(productSetting)) {
                return undefined;
            }

            var template = productSetting[type];
            if (angular.isUndefined(template)) {
                return undefined;
            }

            var templateUrl = template.templateUrl;
            if (angular.isFunction(templateUrl)) {
                templateUrl = templateUrl(data);
            }

            var controller = template.controller;
            if (angular.isFunction(controller)) {
                controller = controller(data);
            }

            var service = template.service;
            if (angular.isFunction(service)) {
                service = service(data);
            }

            return {
                templateUrl: templateUrl,
                controller: controller,
                service: service
            };
        }
    }
})(angular, undefined);