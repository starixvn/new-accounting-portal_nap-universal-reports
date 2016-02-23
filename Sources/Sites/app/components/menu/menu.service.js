(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('menuService', menuService);

    menuService.$inject = ['$http', 'httpResponseService'];
    function menuService($http, httpResponseService) {
        var service = {
            getData: getData,
            getCssClass: getCssClass
        };
        return service;

        function getData() {
            var menus = getRawData();
            for (var i = 0; i < menus.length; i++) {
                var menu = menus[i];
                menu.cssClass = getCssClass(menu, i, menus.length);
                menu.Url = napConfig.LegacyPath + menu.Url;

                for (var j = 0; j < menu.Children.length; j++) {
                    menu.Children[j].Url = napConfig.LegacyPath + menu.Children[j].Url;
                }
            }

            return menus;
        }

        function getRawData() {
            return $http.post('api/application/menu', {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
       
        function getCssClass(menu, index, menuCount) {
            if (index == 0 && menu.Children.length == 0) {
                return "first";
            }

            if (index == 0 && menu.Children.length >= 0) {
                return "first has-child";
            }

            if (index != 0 && index == menuCount - 1) {
                return "last";
            }

            if (index != 0 && index == menuCount - 1 && menu.Children.length >= 0) {
                return "last has-child";
            }

            return "";
        }
    }
})();