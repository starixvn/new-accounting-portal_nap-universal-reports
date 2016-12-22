import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('headerService', headerService);

    headerService.$inject = ['$http', 'universalMenus', 'httpResponseService', 'legacyService'];
    function headerService($http, universalMenus, httpResponseService, legacyService) {
        var service = {
            getData: getData,
            getCompiledMenu: getCompiledMenu,
            getMenuUrl: getMenuUrl
        };
        return service;

        function getCompiledMenu(menus) {
            for (var i = 0; i < menus.length; i++) {
                var menu = menus[i];

                if (menu.Children && menu.Children.length > 0) {
                    menu.Url = menu.Link;
                    for (var j = 0; j < menu.Children.length; j++) {
                        menu.Children[j].Url = getMenuUrl(menu.Children[j].Link);
                    }
                } else {
                    menu.Url = getMenuUrl(menu.Link);
                }
            }

            return menus;
        }

        function getData() {
            return $http.post('api/application/header', {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getMenuUrl(url) {
            for (var i = 0; i < universalMenus.length; i++) {
                if (url.indexOf(universalMenus[i]) >= 0) {
                    return url;
                }
            }

            return legacyService.resolveUrl(url);
        }
    }
})(angular);