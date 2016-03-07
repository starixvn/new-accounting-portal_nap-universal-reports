/* Author: Nexcel -  2016-03-07 */
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp', [
            'app.core'
        ]);
})();
(function () {
    'use strict';

    var levels = {
        PRODUCT: 1,
        THIRD_PARTY_PRODUCT: 2,
        SPORT_TYPE: 3,
        BET_TYPE: 4,
        SITE: 5,
        DETAIL: 6
    };

    var levelSettings = {
        'Product': {
            templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
            controller: 'ProductController'
        },
        'Number Game': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/number-game/number-game.html',
                controller: 'NumberGameBetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController'
            }]
        },
        'Virtual Sports': {
            templates: [{
                level: levels.SPORT_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController'
            },
            {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-detail.html',
                controller: function (gridModel) {
                    return gridModel.sportType >= 181 && gridModel.sportType <= 185 ? 'VirtualSportsRacingDetailController' : 'VirtualSportsSportsbookDetailController'
                }
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Live Casino': {
            templates: [{
                level: levels.THIRD_PARTY_PRODUCT,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ThirdPartyProductController'
            }, {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Casino': {
            templates: [{
                level: levels.THIRD_PARTY_PRODUCT,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ThirdPartyProductController'
            }, {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Racing': {
            templates: [{
                level: levels.SPORT_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-sport-type.html',
                controller: 'SportTypeController'
            },
            {
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Keno': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Bettrade': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
                {
                    level: levels.SITE,
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'SiteController'
                }]
        },
        'Bingo': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Colossus Bets': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
        'Cockfighting': {
            templates: [{
                level: levels.BET_TYPE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController'
            },
            {
                level: levels.DETAIL,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title-for-sport-type.html',
                controller: 'CockfightingDetailController'
            },
            {
                level: levels.SITE,
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController'
            }]
        },
    };

    angular
        .module('app.companyWinlossApp')
        .constant('levels', levels)
        .constant('levelSettings', levelSettings);
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = ['$scope', 'levels', 'companyWinlossService'];
    function CompanyWinlossController($scope, levels, companyWinlossService) {
        companyWinlossService.scope = $scope;
        companyWinlossService.gridModel = this;
        var vm = this;
        vm.level = levels.PRODUCT;
        vm.levels = levels;
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['$timeout', 'levels'];
    function companyWinlossService($timeout, levels) {
        var service = {
            scope: {},
            gridModel: {},
            filterModel: {},
            updateGridModel: updateGridModel,
            getExcelFileName: getExcelFileName,
            generate: generate
        };
        return service;

        function generate(data) {
            var hasGenerate = data.level === undefined || this.gridModel.level <= data.level;
            this.updateGridModel(data);
            if (hasGenerate) {
                this.scope.$broadcast('generate', this.gridModel.level);
            } else {
                this.scope.$broadcast('show', this.gridModel.level);
            }
        }

        function updateGridModel(data) {
            var dateRange = this.filterModel.getDateRange();
            this.gridModel.startDate = dateRange.startDate;
            this.gridModel.endDate = dateRange.endDate;
            this.gridModel.level = angular.isDefined(data.level) ? data.level : this.gridModel.level;
            this.gridModel.productName = angular.isDefined(data.productName) ? data.productName : this.gridModel.productName;
            this.gridModel.thirdPartyProductId = angular.isDefined(data.thirdPartyProductId) ? data.thirdPartyProductId : this.gridModel.thirdPartyProductId;
            this.gridModel.thirdPartyProductName = angular.isDefined(data.thirdPartyProductName) ? data.thirdPartyProductName : this.gridModel.thirdPartyProductName;
            this.gridModel.sportType = angular.isDefined(data.sportType) ? data.sportType : this.gridModel.sportType;
            this.gridModel.sportTypeName = angular.isDefined(data.sportTypeName) ? data.sportTypeName : this.gridModel.sportTypeName;
            this.gridModel.isLive = angular.isDefined(data.isLive) ? data.isLive : this.gridModel.isLive;
            this.gridModel.betType = angular.isDefined(data.betType) ? data.betType : this.gridModel.betType;
            this.gridModel.betTypeName = angular.isDefined(data.betTypeName) ? data.betTypeName : this.gridModel.betTypeName;
            this.gridModel.site = angular.isDefined(data.site) ? data.site : this.gridModel.site;
        }

        function getExcelFileName() {
            return 'Company_Win_Loss_By_Products_From_' + this.gridModel.startDate.format('DD_MM_YYYY') + '_To_' + this.gridModel.endDate.format('DD_MM_YYYY') + '.xls';
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('bettradeBetTypeService', bettradeBetTypeService);

    bettradeBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper', 'breadcrumbHelper'];
    function bettradeBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/bettrade/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/bettrade/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
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
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('bingoBetTypeService', bingoBetTypeService);

    bingoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper', 'breadcrumbHelper'];
    function bingoBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/bingo/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/bingo/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('bingoSiteService', bingoSiteService);

    bingoSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function bingoSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
            return $http.post('/api/company-win-loss/keno/site', data)
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

            return $http.post('/api/company-win-loss/keno/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('casinoBetTypeService', casinoBetTypeService);

    casinoBetTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function casinoBetTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createLinks,
            generateSite: generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                productId: gridModel.thirdPartyProductId
            };
            return $http.post('/api/company-win-loss/casino/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                productId: gridModel.thirdPartyProductId
            };

            return $http.post('/api/company-win-loss/casino/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('casinoSiteService', casinoSiteService);

    casinoSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function casinoSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
            return $http.post('/api/company-win-loss/casino/site', data)
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
            return $http.post('/api/company-win-loss/casino/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('casinoThirdPartyProductService', casinoThirdPartyProductService);

    casinoThirdPartyProductService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'levels', 'breadcrumbHelper'];
    function casinoThirdPartyProductService($http, httpResponseService, companyWinlossService, levels, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            generateBetType: generateBetType,
            createLinks: createLinks
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/casino/third-party-product', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/casino/third-party-product/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function generateBetType(thirdPartyProductId, thirdPartyProductName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                thirdPartyProductId: thirdPartyProductId,
                thirdPartyProductName: thirdPartyProductName
            });
        };

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('cockfightingBetTypeService', cockfightingBetTypeService);

    cockfightingBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'levels', 'breadcrumbHelper'];
    function cockfightingBetTypeService($http, httpResponseService, companyWinlossService, levels, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createSiteLinks,
            generateDetail: generateDetail,
            generateSite: generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function createSiteLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                data.bodyRows[i].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateDetail(\'' + betTypeName + '\')">' + betTypeName + '</a>';
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateDetail(betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betTypeName: betTypeName
            });
        }

        function generateSite(betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betTypeName: betTypeName,
                site: site
            });
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CockfightingDetailController', CockfightingDetailController);

    CockfightingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'cockfightingDetailService', 'breadcrumbHelper'];
    function CockfightingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, cockfightingDetailService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate(startDate, endDate) {
            cockfightingDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            data.defaultCollapseAllGroups = true;
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            cockfightingDetailService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('cockfightingDetailService', cockfightingDetailService);

    cockfightingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function cockfightingDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/match-detail', data)
                 .then(httpResponseService.getDataComplete)
                 .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/cock-fighting/match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('cockfightingSiteService', cockfightingSiteService);

    cockfightingSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function cockfightingSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/cock-fighting/site', data)
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
            return $http.post('/api/company-win-loss/cock-fighting/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('colossusBetsBetTypeService', colossusBetsBetTypeService);

    colossusBetsBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper', 'breadcrumbHelper'];
    function colossusBetsBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/colossus-bets/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/colossus-bets/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('colossusBetsSiteService', colossusBetsSiteService);

    colossusBetsSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function colossusBetsSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
            return $http.post('/api/company-win-loss/colossus-bets/site', data)
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

            return $http.post('/api/company-win-loss/colossus-bets/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('BetTypeController', BetTypeController);

    BetTypeController.$inject = ['$injector', '$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper', 'fanexGridHelper'];
    function BetTypeController($injector, $compile, $scope, $element, companyWinlossService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        var service = getService();
        $scope.generate = generate;
        $scope.generateSite = service.generateSite;
        $scope.generateDetail = service.generateDetail;
        $scope.show = show;

        function getService() {
            var productName = companyWinlossService.gridModel.productName.replace(/\s+/g, '');
            var camelProductName = productName.charAt(0).toLowerCase() + productName.slice(1);
            var serviceName = camelProductName + 'BetTypeService';
            return $injector.get(serviceName);
        };

        function generate() {
            service.getData().then(function (data) {
                $scope.data = angular.copy(data);
                $scope.data.TitleInfoText = breadcrumbHelper.generateText();
                service.createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            service.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('breadcrumbHelper', breadcrumbHelper);

    breadcrumbHelper.$inject = ['$compile', 'levels', 'levelSettings', 'companyWinlossService'];
    function breadcrumbHelper($compile, levels, levelSettings, companyWinlossService) {
        var gridModel = companyWinlossService.gridModel;
        var currentScope;
        var service = {
            generateHtml: generateHtml,
            generateList: generateList,
            generateText: generateText,
            compile: compile
        };
        return service;

        function generateBreadcrumbItems(isLive) {
            var breadcrumbItems = [];
            if (gridModel.level === levels.PRODUCT) {
                breadcrumbItems.push({
                    text: 'Product Win/Loss Report',
                    level: levels.PRODUCT
                });
            } else {
                breadcrumbItems.push({
                    text: 'Main',
                    level: levels.PRODUCT
                });
                var level = levels.PRODUCT;
                var text = gridModel.productName;
                var productSetting = levelSettings[gridModel.productName];
                for (var i = 0; i < productSetting.templates.length; i++) {
                    var productSettingTemplate = productSetting.templates[i];
                    var maxLevel = Math.min(levels.BET_TYPE, gridModel.level);
                    if (productSettingTemplate.level > maxLevel) break;

                    var isActive = productSettingTemplate.level === gridModel.level;
                    var nextText = undefined;
                    var isAdded = true;
                    switch (productSettingTemplate.level) {
                        case levels.THIRD_PARTY_PRODUCT:
                            nextText = gridModel.thirdPartyProductName;
                            break;

                        case levels.SPORT_TYPE:
                            nextText = gridModel.sportTypeName;
                            break;

                        case levels.BET_TYPE:
                            nextText = gridModel.betTypeName;
                            break;

                        case levels.DETAIL:
                        case levels.SITE:
                            isAdded = isActive;
                            break;
                    }

                    breadcrumbItems.push({
                        text: text,
                        level: productSettingTemplate.level,
                        isLive: isLive
                    });
                    text = nextText;
                }

                if (gridModel.level === levels.DETAIL || gridModel.level === levels.SITE) {
                    breadcrumbItems.push({
                        text: text,
                        level: gridModel.level,
                        isLive: isLive
                    });
                }
            }

            return breadcrumbItems;
        }

        function getLiveText(isLive) {
            return angular.isDefined(isLive)
                ? isLive ? ' "Live"' : ' "Non-Live"'
                : '';
        }

        function generateBreadcrumbText(breadcrumbItem, isLast) {
            switch (breadcrumbItem.level) {
                case levels.PRODUCT:
                    return breadcrumbItem.text;

                case levels.THIRD_PARTY_PRODUCT:
                case levels.SPORT_TYPE:
                case levels.BET_TYPE:
                    return isLast
                        ? breadcrumbItem.text + getLiveText(breadcrumbItem.isLive) + ' Product Win/Loss Report'
                        : breadcrumbItem.text;

                case levels.DETAIL:
                    return breadcrumbItem.text + getLiveText(breadcrumbItem.isLive);

                case levels.SITE:
                    return breadcrumbItem.text + getLiveText(breadcrumbItem.isLive) + ' | Product Win Loss By ' + gridModel.site + ' Site'
            }
        }

        function generateList(isLive) {
            var breadcrumbItems = generateBreadcrumbItems(isLive);
            var list = [];
            for (var i = 0; i < breadcrumbItems.length; i++) {
                var breadcrumbItem = breadcrumbItems[i];
                var isLast = i === breadcrumbItems.length - 1;
                var breadcrumbText = generateBreadcrumbText(breadcrumbItem, isLast);
                list.push(breadcrumbText);
            }

            return list;
        }

        function generateText(isLive) {
            var list = this.generateList(isLive);
            return list.join(' > ');
        }

        function generateHtml(scope, isLive) {
            currentScope = scope;
            currentScope.breadcrumbClicked = breadcrumbClicked;
            var html = '<ol class="breadcrumb">';
            var breadcrumbItems = generateBreadcrumbItems(isLive);
            var list = [];
            for (var i = 0; i < breadcrumbItems.length; i++) {
                var breadcrumbItem = breadcrumbItems[i];
                var isLast = i === breadcrumbItems.length - 1;
                var breadcrumbText = generateBreadcrumbText(breadcrumbItem, isLast);
                if (isLast) {
                    html += '<li class="active">' + breadcrumbText + '</li>';
                } else {
                    html += '<li><a href data-ng-click="breadcrumbClicked(' + breadcrumbItem.level + ')">' + breadcrumbText + '</a></li>';
                }
            }

            html += '</ol>';
            return html;
        }

        function breadcrumbClicked(level) {
            companyWinlossService.generate({
                level: level
            });
        }

        function compile($element) {
            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)(currentScope);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('kenoDrilldownStyleHelper', kenoDrilldownStyleHelper);

    kenoDrilldownStyleHelper.$inject = ['levels', 'companyWinlossService'];
    function kenoDrilldownStyleHelper(levels, companyWinlossService) {
        var service = {
            createSiteLinks: createSiteLinks,
            generateSite: generateSite,
        };
        return service;

        function createSiteLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SiteController', SiteController);

    SiteController.$inject = ['$injector', '$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper', 'fanexGridHelper'];
    function SiteController($injector, $compile, $scope, $element, companyWinlossService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        var service = getService();

        $scope.generate = generate;
        $scope.show = show;

        function getService() {
            var productName = companyWinlossService.gridModel.productName.replace(/\s+/g, '');
            var camelProductName = productName.charAt(0).toLowerCase() + productName.slice(1);
            var serviceName = camelProductName + 'SiteService';
            return $injector.get(serviceName);
        };

        function generate() {
            service.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            service.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportTypeController', SportTypeController);

    SportTypeController.$inject = ['$injector', '$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper', 'fanexGridHelper'];
    function SportTypeController($injector, $compile, $scope, $element, companyWinlossService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        var service = getService();

        $scope.generate = generate;
        $scope.generateBetType = service.generateBetType;
        $scope.show = show;

        function getService() {
            var productName = companyWinlossService.gridModel.productName.replace(/\s+/g, '');
            var camelProductName = productName.charAt(0).toLowerCase() + productName.slice(1);
            var serviceName = camelProductName + 'SportTypeService';
            return $injector.get(serviceName);
        };

        function generate() {
            service.getData().then(function (data) {
                service.createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            service.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ThirdPartyProductController', ThirdPartyProductController);

    ThirdPartyProductController.$inject = ['$injector', '$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper'];
    function ThirdPartyProductController($injector, $compile, $scope, $element, companyWinlossService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        var service = getService();

        $scope.generate = generate;
        $scope.generateBetType = service.generateBetType;
        $scope.show = show;

        function getService() {
            var productName = companyWinlossService.gridModel.productName.replace(/\s+/g, '');
            var camelProductName = productName.charAt(0).toLowerCase() + productName.slice(1);
            var serviceName = camelProductName + 'ThirdPartyProductService';
            return $injector.get(serviceName);
        };

        function generate() {
            service.getData().then(function (data) {
                service.createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                showCollapseExpandButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            service.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/company-winloss/filter/filter.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$scope', 'config', 'companyWinlossService'];
        function controller($scope, config, companyWinlossService) {
            companyWinlossService.filterModel = this;
            /*jshint validthis: true */
            var vm = this;
            vm.currentLevel = 0;
            vm.normalMode = true;
            vm.today = config.today;
            vm.yesterday = config.yesterday;
            vm.date = config.today;
            vm.startDate = moment.utc(config.today).startOf('month');
            vm.endDate = config.today;
            vm.generate = generate;
            vm.todayClicked = todayClicked;
            vm.yesterdayClicked = yesterdayClicked;
            vm.viewNormalMode = viewNormalMode;
            vm.viewHistoryMode = viewHistoryMode;
            vm.dateRange = createDateRange();
            vm.getDateRange = getDateRange;
            vm.reloadDateRange = reloadDateRange;
            vm.updateDateRange = updateDateRange;

            function generate() {
                vm.dateRange = createDateRange();
                companyWinlossService.generate({});
            }

            function todayClicked() {
                vm.date = vm.today;
                vm.generate();
            }

            function yesterdayClicked() {
                vm.date = vm.yesterday;
                vm.generate();
            }

            function viewNormalMode() {
                vm.normalMode = true;
            }

            function viewHistoryMode() {
                vm.normalMode = false;
            }

            function createDateRange() {
                if (vm.normalMode) {
                    return {
                        startDate: vm.date,
                        endDate: vm.date
                    };
                } else {
                    return {
                        startDate: vm.startDate,
                        endDate: vm.endDate
                    };
                }
            }

            function getDateRange() {
                return vm.dateRange;
            }

            function reloadDateRange() {
                vm.date = vm.dateRange.startDate;
                vm.startDate = vm.dateRange.startDate;
                vm.endDate = vm.dateRange.endDate;
            }

            function updateDateRange(dateRange) {
                vm.dateRange = dateRange;
                reloadDateRange();
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('kenoBetTypeService', kenoBetTypeService);

    kenoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'kenoDrilldownStyleHelper', 'breadcrumbHelper'];
    function kenoBetTypeService($http, httpResponseService, companyWinlossService, kenoDrilldownStyleHelper, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: kenoDrilldownStyleHelper.createSiteLinks,
            generateSite: kenoDrilldownStyleHelper.generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/keno/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/keno/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('kenoSiteService', kenoSiteService);

    kenoSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function kenoSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
            return $http.post('/api/company-win-loss/keno/site', data)
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
            return $http.post('/api/company-win-loss/keno/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napLevel', napSite);

    napSite.$inject = ['$controller'];
    function napSite($controller) {
        var directive = {
            restrict: 'EA',
            scope: {
                level: '='
            },
            controller: controller
        };
        return directive;

        controller.$inject = ['$log', '$compile', '$timeout', '$element', '$scope', 'levelService', '$templateRequest', 'companyWinlossService'];
        function controller($log, $compile, $timeout, $element, $scope, levelService, $templateRequest, companyWinlossService) {
            var dateRange,
                currentScope;

            $scope.$on('generate', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.reloadDateRange();
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        companyWinlossService.gridModel.startDate = dateRange.startDate;
                        companyWinlossService.gridModel.endDate = dateRange.endDate;
                        currentScope.show();
                    });
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var levelSetting = levelService.getSetting();
                if (angular.isUndefined(levelSetting)) {
                    $log.error('Product level setting is undefined');
                    return;
                }

                $templateRequest(levelSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.html(response);
                    var templateCtrl = $controller(levelSetting.controller, { $scope: templateScope, $element: templateElement });
                    templateElement.data('$ngControllerController', templateCtrl);
                    $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                        if (currentScope) {
                            currentScope.$destroy();
                            currentScope = null;
                        }

                        currentScope = scope;
                        currentScope.generate();
                    });
                });
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('levelService', levelService);

    levelService.$inject = ['levels', 'levelSettings', 'companyWinlossService'];
    function levelService(levels, levelSettings, companyWinlossService) {
        var service = {
            getSetting: getSetting
        };
        return service;

        function getSetting() {
            var gridModel = companyWinlossService.gridModel;
            var levelSetting;
            if (gridModel.level === levels.PRODUCT) {
                var levelSetting = levelSettings.Product;
            } else {
                var productSetting = levelSettings[gridModel.productName];
                for (var i = 0; i < productSetting.templates.length; i++) {
                    var productSettingTemplate = productSetting.templates[i];
                    if (gridModel.level === productSettingTemplate.level) {
                        levelSetting = productSettingTemplate;
                        break;
                    }
                }
            }

            return {
                templateUrl: angular.isFunction(levelSetting.templateUrl) ? levelSetting.templateUrl(gridModel) : levelSetting.templateUrl,
                controller: angular.isFunction(levelSetting.controller) ? levelSetting.controller(gridModel) : levelSetting.controller
            };
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('liveCasinoBetTypeService', liveCasinoBetTypeService);

    liveCasinoBetTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function liveCasinoBetTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createLinks,
            generateSite: generateSite
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                productId: gridModel.thirdPartyProductId
            };
            return $http.post('/api/company-win-loss/live-casino/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                productId: gridModel.thirdPartyProductId
            };

            return $http.post('/api/company-win-loss/live-casino/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('liveCasinoSiteService', liveCasinoSiteService);

    liveCasinoSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function liveCasinoSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
            return $http.post('/api/company-win-loss/live-casino/site', data)
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
            return $http.post('/api/company-win-loss/live-casino/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('liveCasinoThirdPartyProductService', liveCasinoThirdPartyProductService);

    liveCasinoThirdPartyProductService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'levels', 'breadcrumbHelper'];
    function liveCasinoThirdPartyProductService($http, httpResponseService, companyWinlossService, levels, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            generateBetType: generateBetType,
            createLinks: createLinks
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/live-casino/third-party-product', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/live-casino/third-party-product/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function generateBetType(thirdPartyProductId, thirdPartyProductName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                thirdPartyProductId: thirdPartyProductId,
                thirdPartyProductName: thirdPartyProductName
            });
        };

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameBetTypeController', NumberGameBetTypeController);

    NumberGameBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameBetTypeService', 'breadcrumbHelper'];
    function NumberGameBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameBetTypeService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateDetail = generateDetail;
        $scope.generateSite = generateSite;

        function generateDetail(betType, betTypeName, isLive) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive
            });
        };

        function generateSite(betType, betTypeName, site, isLive) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                isLive: isLive,
                betTypeName: betTypeName,
                site: site
            });
        };

        function generate() {
            numberGameBetTypeService.getData().then(function (data) {
                createLinks(data.Live, true);
                createLinks(data.NonLive, false);
                renderGrid(nonliveGridElement, data.NonLive, false);
                renderGrid(liveGridElement, data.Live, true);
                compileLinks();
            });
        }

        function show() {
            nonliveGridElement.fanexGrid('resizeGrid');
            liveGridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data, isLive) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope, isLive),
                showCollapseExpandButton: true,
                showExcelButton: !isLive,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            data.defaultCollapseAllGroups = true;
            gridElement.fanexGrid(data);
        }

        function createLinks(data, isLive) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',' + isLive + ')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\',' + isLive + ')">' + siteName + '</a>';
                }
            }
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            numberGameBetTypeService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameBetTypeService', numberGameBetTypeService);

    numberGameBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function numberGameBetTypeService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/number-game/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                liveTitle: breadcrumbHelper.generateText(true),
                nonLiveTitle: breadcrumbHelper.generateText(false),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/number-game/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameDetailController', NumberGameDetailController);

    NumberGameDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameDetailService', 'breadcrumbHelper'];
    function NumberGameDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameDetailService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate(startDate, endDate) {
            numberGameDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope, gridModel.isLive),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            data.defaultCollapseAllGroups = true;
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            numberGameDetailService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameDetailService', numberGameDetailService);

    numberGameDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function numberGameDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(gridModel.isLive),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType
            };

            return $http.post('/api/company-win-loss/number-game/match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameSiteController', NumberGameSiteController);

    NumberGameSiteController.$inject = ['$compile', '$scope', '$element', 'companyWinlossService', 'breadcrumbHelper', 'fanexGridHelper', 'numberGameSiteService'];
    function NumberGameSiteController($compile, $scope, $element, companyWinlossService, breadcrumbHelper, fanexGridHelper, numberGameSiteService) {
        var gridElement = $element.find('.freegrid');
        var gridModel = companyWinlossService.gridModel;
        $scope.generate = generate;
        $scope.show = show;

        function generate() {
            numberGameSiteService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope, gridModel.isLive),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            numberGameSiteService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameSiteService', numberGameSiteService);

    numberGameSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function numberGameSiteService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/number-game/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(gridModel.isLive),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: 161,
                isLive: gridModel.isLive,
                betType: gridModel.betType,
                site: gridModel.site
            };

            return $http.post('/api/company-win-loss/number-game/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$compile', '$timeout', '$element', '$scope', 'formatStrings', 'productService', 'fanexGridHelper', 'levels', 'levelSettings', 'companyWinlossService', 'breadcrumbHelper'];
    function ProductController($compile, $timeout, $element, $scope, formatStrings, productService, fanexGridHelper, levels, levelSettings, companyWinlossService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var templates = levelSettings[productName].templates;
            var firstTemplate = templates[0];
            companyWinlossService.generate({
                level: firstTemplate.level,
                productName: productName
            });
        };

        function generate() {
            productService.getData().then(function (data) {
                createLinks(data);
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productRow = data.bodyRows[i];
                if (angular.isDefined(productRow.SubRows)) {
                    var productName = productRow.Columns[0].Value;
                    var isSportsbookTotal = productName === 'Sportsbook Total';
                    if (!isSportsbookTotal) {
                        productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProduct(\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
                    }
                }
            }
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            productService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('productService', productService);

    productService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function productService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/product', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/product/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingBetTypeService', racingBetTypeService);

    racingBetTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function racingBetTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createLinks,
            generateSite: generateSite,
            generateDetail: generateDetail,
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType
            };
            return $http.post('/api/company-win-loss/racing/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType
            };

            return $http.post('/api/company-win-loss/racing/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function createLinks(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('RacingDetailController', RacingDetailController);

    RacingDetailController.$inject = ['$compile', '$scope', '$element', 'racingDetailService', 'breadcrumbHelper', 'fanexGridHelper'];
    function RacingDetailController($compile, $scope, $element, racingDetailService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            racingDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            racingDetailService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingDetailService', racingDetailService);

    racingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function racingDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/racing/match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };

            return $http.post('/api/company-win-loss/racing/match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingSiteService', racingSiteService);

    racingSiteService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function racingSiteService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
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
                sportType: gridModel.sportType,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/racing/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType,
                site: gridModel.site
            };

            return $http.post('/api/company-win-loss/racing/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingSportTypeService', racingSportTypeService);

    racingSportTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function racingSportTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createLinks,
            generateBetType: generateBetType
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };
            return $http.post('/api/company-win-loss/racing/sport-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/racing/sport-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
                var sportTypeName = sportTypeRow.Columns[0].Value;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsBetTypeService', virtualSportsBetTypeService);

    virtualSportsBetTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function virtualSportsBetTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createLinks,
            generateSite: generateSite,
            generateDetail: generateDetail,
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType
            };
            return $http.post('/api/company-win-loss/virtual-sports/bet-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType
            };

            return $http.post('/api/company-win-loss/virtual-sports/bet-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function createLinks(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('VirtualSportsRacingDetailController', VirtualSportsRacingDetailController);

    VirtualSportsRacingDetailController.$inject = ['$compile', '$scope', '$element', 'virtualSportsRacingDetailService', 'breadcrumbHelper', 'fanexGridHelper'];
    function VirtualSportsRacingDetailController($compile, $scope, $element, virtualSportsRacingDetailService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            virtualSportsRacingDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            virtualSportsRacingDetailService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsRacingDetailService', virtualSportsRacingDetailService);

    virtualSportsRacingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function virtualSportsRacingDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };

            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsSiteService', virtualSportsSiteService);

    virtualSportsSiteService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function virtualSportsSiteService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
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
                sportType: gridModel.sportType,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/virtual-sports/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType,
                site: gridModel.site
            };

            return $http.post('/api/company-win-loss/virtual-sports/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsSportTypeService', virtualSportsSportTypeService);

    virtualSportsSportTypeService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function virtualSportsSportTypeService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel,
            createLinks: createLinks,
            generateBetType: generateBetType
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/virtual-sports/sport-type', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate
            };

            return $http.post('/api/company-win-loss/virtual-sports/sport-type/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
                var sportTypeName = sportTypeRow.Columns[0].Value;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('VirtualSportsSportsbookDetailController', VirtualSportsSportsbookDetailController);

    VirtualSportsSportsbookDetailController.$inject = ['$compile', '$scope', '$element', 'virtualSportsSportsbookDetailService', 'breadcrumbHelper', 'fanexGridHelper'];
    function VirtualSportsSportsbookDetailController($compile, $scope, $element, virtualSportsSportsbookDetailService, breadcrumbHelper, fanexGridHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            virtualSportsSportsbookDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            virtualSportsSportsbookDetailService.exportExcel();
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsSportsbookDetailService', virtualSportsSportsbookDetailService);

    virtualSportsSportsbookDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'breadcrumbHelper'];
    function virtualSportsSportsbookDetailService($http, httpResponseService, companyWinlossService, breadcrumbHelper) {
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
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/sportsbook-match-detail', data)
                 .then(httpResponseService.getDataComplete)
                 .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType
            };

            return $http.post('/api/company-win-loss/virtual-sports/sportsbook-match-detail/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();