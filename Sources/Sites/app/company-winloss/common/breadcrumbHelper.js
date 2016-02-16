(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('breadcrumbHelper', breadcrumbHelper);

    breadcrumbHelper.$inject = [];
    function breadcrumbHelper() {
        var service = {
            generateHtml: generateHtml
        };
        return service;

        function generateHtml(scope) {

        }
    }
})();