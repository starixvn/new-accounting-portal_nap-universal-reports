(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('menuService', menuService);

    menuService.$inject = ['$http', 'universalMenus', 'httpResponseService'];
    function menuService($http, universalMenus, httpResponseService) {
        var service = {
            getData: getData,
            getCompiledMenu: getCompiledMenu,
            getCssClass: getCssClass,
            getMenuUrl: getMenuUrl
        };
        return service;

        function getCompiledMenu(menus) {
            for (var i = 0; i < menus.length; i++) {
                var menu = menus[i];
                
                for (var j = 0; j < menu.Children.length; j++) {
                    menu.Children[j].Url = getMenuUrl(menu.Children[j].Url);
                }
            }

            return menus;
        }

        function getData() {
            return $http.post('api/application/menu', {})
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