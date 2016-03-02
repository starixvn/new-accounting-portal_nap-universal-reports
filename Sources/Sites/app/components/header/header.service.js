(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('headerService', headerService);

    headerService.$inject = ['$http', 'universalMenus', 'httpResponseService'];
    function headerService($http, universalMenus, httpResponseService) {
        var service = {
            getData: getData,
            getCompiledMenu: getCompiledMenu,
            getMenuUrl: getMenuUrl
        };
        return service;

        function getCompiledMenu(menus) {
            for (var i = 0; i < menus.length; i++) {
                var menu = menus[i];

                if (menu.Children.length > 0) {
                    for (var j = 0; j < menu.Children.length; j++) {
                        menu.Children[j].Url = getMenuUrl(menu.Children[j].Url);
                    }
                } else {
                    menu.Url = getMenuUrl(menu.Url);
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

            return napConfig.LegacyPath + url;
        }
    }
})();