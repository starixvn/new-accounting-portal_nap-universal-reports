(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp', [
            'app.core'
        ]);
})(angular);
(function (angular) {
    'use strict';

    var templateSetting = {
        'Soccer': {
            product: 'soccer',
            soccer: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerController',
                service: 'soccerMajorMinorService'
            },
            soccerLiveNonLive: { // child of soccer
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SoccerLiveNonLiveController',
                service: 'soccerMajorMinorService'
            },
            soccerBetType: { // child of soccer
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SoccerBetTypeController',
                service: 'soccerBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
            }
        },
        'Metric Gaming - Superlive': {
            product: 'liveNonLive',
            liveNonLive: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'MetricGamingLiveNonLiveController',
                service: 'metricGamingLiveNonLiveService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportsbookProductViewBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'metricGamingMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'metricGamingSiteService'
            }
        },
        'Other Sports': {
            product: 'liveNonLive',
            liveNonLive: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'OtherSportsLiveNonLiveController',
                service: 'otherSportsLiveNonLiveService'
            },
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookSportTypeController',
                service: 'sportsbookSportTypeService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportsbookSportTypeViewBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
            }
        },
        'Parlay': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'ParlayBetTypeController',
                service: 'parlayBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'parlaySiteService'
            }
        },
        'Live Casino': {
            product: 'casinoProduct',
            casinoProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'CasinoProductController',
                service: 'casinoProductService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'CasinoBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Casino': {
            product: 'casinoProduct',
            casinoProduct: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'CasinoProductController',
                service: 'casinoProductService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'CasinoBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Number Game': {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/two-fanex-grid-with-title.html',
                controller: 'NumberGameBetTypeController',
                service: 'numberGameBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: 'numberGameMatchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'numberGameSiteService'
            }
        },
        'Virtual Sports': {
            product: 'sportType',
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'sportTypeService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportTypeViewBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: function (data) {
                    return data.sportType >= 181 && data.sportType <= 185 ? 'virtualSportsRacingDetailService' : 'virtualSportsSportsbookDetailService';
                }
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },


        'Racing': {
            product: 'sportType',
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'sportTypeService'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportTypeViewBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: 'matchDetailService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        }
    };
    var universalSettings = {
        products: {
            "Bettrade": 0,
            "Bingo": 7,
            "Keno": 8,
            "Colossus Bets": 15
        },
        settings: {
            product: 'betType',
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'universalBetTypeService'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'universalSiteService'
            }
        },
        getProductId: function (productName) {
            return universalSettings.products[productName];
        }
    };
    angular
        .module('app.companyWinlossApp')
        .constant('templateSetting', templateSetting)
        .constant('universalSettings', universalSettings);
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = [];
    function CompanyWinlossController() {
        var vm = this;
        vm.panes = [];
    }
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['templateSetting', 'universalSettings'];
    function companyWinlossService(templateSetting, universalSettings) {
        var service = {
            getTemplate: getTemplate,
            getTemplateSetting: getTemplateSetting,
            resolveProductPath: resolveProductPath
        };
        return service;

        function resolveProductPath(productName) {
            if (productName == 'Live Casino' || productName == 'Casino')
            {
                return 'casino';
            }

            return productName.replace(/\s+/g, '-').replace(/\-+/g, '-');
        }

        function getTemplateSetting(productName) {
            var productSetting = templateSetting[productName];
            if (!angular.isUndefined(productSetting)) {
                return productSetting;
            }

            return universalSettings.settings;
        }

        function getTemplate(data, type) {
            if (type === 'product') {
                return {
                    templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                    controller: 'ProductController',
                    service: 'productService'
                };
            }

            var productSetting = getTemplateSetting(data.productName);
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
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('breadcrumbService', breadcrumbService);

    breadcrumbService.$inject = [];
    function breadcrumbService() {
        var service = {
            generateHtml: generateHtml,
            generateText: generateText
        };
        return service;

        function generateHtml(list) {
            var html = '<ol class="breadcrumb">';
            for (var i = 0; i < list.length; i++) {
                var title = list[i];
                var isLast = i === list.length - 1;
                if (isLast) {
                    html += '<li class="active">' + title + '</li>';
                } else {
                    html += '<li><a href data-ng-click="tab.goBack(' + i + ')">' + title + '</a></li>';
                }
            }

            return html;
        }

        function generateText(list) {
            return list.join(' > ');
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('liveTitleService', liveTitleService);

    liveTitleService.$inject = [];
    function liveTitleService() {

        var service = {
            getProductTitle: getProductTitle,
            getSportTypeTitle: getSportTypeTitle,
            getSiteTitle: getSiteTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getLiveText(isLive) {
            return ' "' + (isLive ? 'Live' : 'Non-Live') + '" ';
        }

        function getSiteText(site) {
            return site + ' Site';
        }

        function getProductTitle(data) {
            return data.productName + getLiveText(data.isLive);
        }

        function getSportTypeTitle(data) {
            return data.sportTypeName + getLiveText(data.isLive);
        }

        function getSiteTitle(data) {
            return data.betTypeName + getLiveText(data.isLive) + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName + getLiveText(data.isLive) ;
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('titleService', titleService);

    titleService.$inject = [];
    function titleService() {
        var productWinLossReport = 'Product Win/Loss Report' ;

        var service = {
            getMainTitle: getMainTitle,
            getProductTitle: getProductTitle,
            getProductLiveNonLiveTitle: getProductLiveNonLiveTitle,
            getCasinoProductTitle: getCasinoProductTitle,
            getSportTypeTitle: getSportTypeTitle,
            getSiteTitle: getSiteTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getSiteText(site) {
            return '| ' + (site == undefined ? "ALL" : site) + ' Site';
        }

        function getMainTitle(data) {
            return 'Main';
        }

        function getProductTitle(data) {
            return data.productName;
        }

        function getProductLiveNonLiveTitle(data, isLast) {
            return isLast ? data.productName + ' Live/Non-Live ' : data.productName;
        }

        function getCasinoProductTitle(data) {
            return data.casinoProductName;
        }

        function getSportTypeTitle(data) {
            return data.sportTypeName;
        }

        function getSiteTitle(data) {
            return data.betTypeName + ' ' + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName;
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('CasinoBetTypeService', CasinoBetTypeService);

    CasinoBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function CasinoBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getCasinoProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                productId: data.casinoProductId,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/casino/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                productId: data.casinoProductId,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = 'api/company-win-loss/casino/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CasinoProductController', CasinoProductController);

    CasinoProductController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function CasinoProductController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(productId, productName) {
            var data = {
                casinoProductId: productId,
                casinoProductName: productName
            };
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                showCollapseExpandButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('casinoProductService', casinoProductService);

    casinoProductService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function casinoProductService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                casinoType: data.productName == 'Casino' ? 1 : 2
            };

            var url = 'api/company-win-loss/casino/product';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                casinoType: data.productName == 'Casino' ? 1 : 2
            };

            var url = 'api/company-win-loss/casino/product/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('BetTypeController', BetTypeController);

    BetTypeController.$inject = ['$scope', '$element', 'companyWinlossService', 'fanexGridService', 'showHideColumnService'];
    function BetTypeController($scope, $element, companyWinlossService, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateSite = generateSite;
        $scope.generateMatchDetail = generateMatchDetail;

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generateMatchDetail(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);

                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data);
                }
                
                renderGrid(data);
                pane.compileAll();
            });
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') <= 3;
        }

        function createLinks(data) {
            var template = companyWinlossService.getTemplate(pane.data, 'matchDetail');
            var hasDetailDrilldown = angular.isDefined(template);
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                var betTypeId = betTypeRow.Columns[0].CustomAttr;
                if (hasDetailDrilldown) {
                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
                }

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MatchDetailController', MatchDetailController);

    MatchDetailController.$inject = ['$scope', '$element', 'fanexGridService'];
    function MatchDetailController($scope, $element, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.showPager = true;
            data.pagerOption = {
                itemsPerPage: 50,
                currentPage: 0,
                itemsPerPageArray: [50, 100, 200, 500],
                totalItem: data.bodyRows.length
            };

            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.headerColumnHeight = 10;
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('matchDetailService', matchDetailService);

    matchDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function matchDetailService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SiteController', SiteController);

    SiteController.$inject = ['$injector', '$scope', '$element', 'fanexGridService'];
    function SiteController($injector, $scope, $element, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('siteService', siteService);

    siteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function siteService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportTypeViewBetTypeService', sportTypeViewBetTypeService);

    sportTypeViewBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportTypeViewBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSportTypeTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportTypeController', SportTypeController);

    SportTypeController.$inject = ['$injector', '$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function SportTypeController($injector, $scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(sportType, sportTypeName) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
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

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportTypeService', sportTypeService);

    sportTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
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
    }

    controller.$inject = ['$scope', '$rootScope', 'config'];
    function controller($scope, $rootScope, config) {
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
        $scope.$on('nap-filter-date', function (event, data) {
            updateDateRange(data);
        });

        function generate() {
            vm.dateRange = createDateRange();
            $rootScope.$broadcast('nap-filter-generate', vm.dateRange);
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
            $rootScope.$broadcast('nap-filter-switch');
        }

        function viewHistoryMode() {
            vm.normalMode = false;
            $rootScope.$broadcast('nap-filter-switch');
        }

        function createDateRange() {
            if(vm.normalMode) {
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
            if(vm.dateRange.startDate === vm.dateRange.endDate) {
                vm.normalMode = true;
                vm.date = vm.dateRange.startDate;
            } else {
                vm.normalMode = false;
                vm.startDate = vm.dateRange.startDate;
                vm.endDate = vm.dateRange.endDate;
            }
        }

        function updateDateRange(dateRange) {
            vm.dateRange = dateRange;
            reloadDateRange();
        }
        }
        }) (angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .service('productShowHideColumnService', productShowHideColumnService);

    productShowHideColumnService.$inject = ['$log', '$timeout'];
    function productShowHideColumnService($log, $timeout) {
        var service = {
            defaultCollapseAllGroups: true,
            Builder: Builder
        };
        return service;

        function Builder(pane) {
            var defaultCollapseAllGroups = service.defaultCollapseAllGroups;
            var hiddenColumns = [1, 2];
            this.getButtonHtml = getButtonHtml;
            this.build = build;
            this.toggle = toggle;

            function toggle() {
                if (defaultCollapseAllGroups !== service.defaultCollapseAllGroups) {
                    var customButton = pane.$element.find('.btExpand').first();
                    $timeout(function () {
                        customButton.trigger('click');
                    });
                }
            }

            function getButtonHtml() {
                var buttonClass = !defaultCollapseAllGroups ? 'expanded' : 'collapsed';
                return '<input type="button" class="btExpand customized ' + buttonClass + ' nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
            }

            function build(listOfGridElements, listOfGridOptions) {
                if (!angular.isArray(listOfGridElements)) {
                    listOfGridElements = [listOfGridElements];
                }
                if (!angular.isArray(listOfGridOptions)) {
                    listOfGridOptions = [listOfGridOptions];
                }
                if (listOfGridElements.length !== listOfGridOptions.length) {
                    $log.error('Invalid parameters');
                    return;
                }

                pane.$scope.showHideColumns = showHideColumns;
                for (var i = 0; i < listOfGridOptions.length; i++) {
                    var gridOptions = listOfGridOptions[i];
                    gridOptions.hiddenColumns = hiddenColumns;
                    gridOptions.enableHiddenColumns = !defaultCollapseAllGroups;
                    gridOptions.defaultCollapseAllGroups = defaultCollapseAllGroups;
                }

                function showHideColumns($event) {
                    defaultCollapseAllGroups = !defaultCollapseAllGroups;
                    service.defaultCollapseAllGroups = defaultCollapseAllGroups;
                    for (var i = 0; i < listOfGridOptions.length; i++) {
                        var gridElement = listOfGridElements[i];
                        var gridOptions = listOfGridOptions[i];
                        gridOptions.enableHiddenColumns = defaultCollapseAllGroups;
                        gridOptions.defaultCollapseAllGroups = true;
                        if (gridOptions.enableHiddenColumns) {
                            gridElement.fanexGrid("hideColumns", gridOptions, hiddenColumns);
                        } else {
                            gridElement.fanexGrid("hideColumns", gridOptions, []);
                        }
                    }

                    pane.compileDrilldown();
                    var target = angular.element($event.target);
                    if (!defaultCollapseAllGroups) {
                        target.removeClass('collapsed').addClass('expanded');
                    } else {
                        target.removeClass('expanded').addClass('collapsed');
                    }
                }
            }
        };
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('showHideColumnService', showHideColumnService);

    showHideColumnService.$inject = ['$log', '$timeout', 'productShowHideColumnService'];
    function showHideColumnService($log, $timeout, productShowHideColumnService) {
        function Builder(pane) {
            var defaultCollapseAllGroups = productShowHideColumnService.defaultCollapseAllGroups;
            this.getButtonHtml = getButtonHtml;
            this.build = build;
            this.toggle = toggle;

            function raiseDefaultClick() {
                var buttons = pane.$element.find('.btExpand');
                var customButton = buttons.first();
                if (defaultCollapseAllGroups) {
                    customButton.removeClass('collapsed').addClass('expanded');
                } else {
                    customButton.removeClass('expanded').addClass('collapsed');
                }

                var defaultButtons = buttons.not(':eq(0)');
                $timeout(function () {
                    defaultButtons.trigger('click');
                });
            }

            function toggle() {
                if (defaultCollapseAllGroups != productShowHideColumnService.defaultCollapseAllGroups) {
                    defaultCollapseAllGroups = productShowHideColumnService.defaultCollapseAllGroups;
                    raiseDefaultClick();
                }
            }

            function getButtonHtml() {
                var buttonClass = !defaultCollapseAllGroups ? 'expanded' : 'collapsed';
                return '<input type="button" class="btExpand customized ' + buttonClass + ' nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
            }

            function build(listOfGridElements, listOfGridOptions) {
                if (!angular.isArray(listOfGridElements)) {
                    listOfGridElements = [listOfGridElements];
                }
                if (!angular.isArray(listOfGridOptions)) {
                    listOfGridOptions = [listOfGridOptions];
                }
                if (listOfGridElements.length !== listOfGridOptions.length) {
                    $log.error('Invalid parameters');
                    return;
                }

                pane.$scope.showHideColumns = showHideColumns;
                for (var i = 0; i < listOfGridOptions.length; i++) {
                    var gridOptions = listOfGridOptions[i];
                    gridOptions.defaultCollapseAllGroups = defaultCollapseAllGroups;
                }

                function showHideColumns($event) {
                    defaultCollapseAllGroups = !defaultCollapseAllGroups;
                    productShowHideColumnService.defaultCollapseAllGroups = defaultCollapseAllGroups;
                    raiseDefaultClick();
                }
            }
        };

        return Builder;
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingBetTypeService', metricGamingBetTypeService);

    metricGamingBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MetricGamingLiveNonLiveController', MetricGamingLiveNonLiveController);
    MetricGamingLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'metricGamingBetTypeService', 'metricGamingLiveNonLiveService', 'showHideColumnService', 'titleService'];

    function MetricGamingLiveNonLiveController($scope, $element, fanexGridService, metricGamingBetTypeService, metricGamingLiveNonLiveService, showHideColumnService, titleService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var getProductTitle = titleService.getProductTitle;
        var getProductLiveNonLiveTitle = pane.service.getTitle;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var betTypeGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;
        $scope.generateMatchDetail = generateMatchDetail;
        $scope.generateSite = generateSite;

        function generateBetType(isLive) {
            var data = {
                isLive: isLive
            }
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generateMatchDetail(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generateSite(betType, betTypeName, site, isHegde) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site,
                isHegde: isHegde
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generate() {
            var betTypeGridOptions,
                liveNonLiveGridOptions;
            var renderAll = function () {
                if (angular.isDefined(betTypeGridOptions) && angular.isDefined(liveNonLiveGridOptions)) {
                    showHideColumnBuilder.build([betTypeGridElement, liveNonLiveGridElement], [betTypeGridOptions, liveNonLiveGridOptions]);
                    createLinksForBetType(betTypeGridOptions);
                    renderGridForBetType(betTypeGridOptions);
                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    renderGridForLiveNonLive(liveNonLiveGridOptions);
                    pane.compileAll();
                }
            };

            metricGamingBetTypeService.getData(pane.data).then(function (data) {
                betTypeGridOptions = data;
                renderAll();
            });

            pane.service.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
                renderAll();
            });
        }

        function renderGridForBetType(data) {
            pane.service.getTitle = getProductTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(betTypeGridElement, true);
            betTypeGridElement.fanexGrid(data);
        }

        function renderGridForLiveNonLive(data) {
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false
            };

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(liveNonLiveGridElement, true);
            liveNonLiveGridElement.fanexGrid(data);
        }

        function createLinksForBetType(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                var isHegde = betTypeName.match("hegde") ? true : false;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\',' + isHegde + ')">' + siteName + '</a>';
                }
            }
        }

        function createLinksForLiveNonLive(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var row = data.bodyRows[i];
                var name = row.Columns[0].Value;
                var isLive = parseInt(row.Columns[0].CustomAttr);
                row.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + isLive + ')">' + name + '</a>';
            }
        }

        function exportExcel() {
            pane.service.getTitle = getProductTitle;
            var sportTypeTitle = tab.generateBreadcrumbText();
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            metricGamingLiveNonLiveService.exportExcel(sportTypeTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingLiveNonLiveService', metricGamingLiveNonLiveService);

    metricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingLiveNonLiveService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductLiveNonLiveTitle,
            getData: getData,
            exportExcel: exportExcel
        }
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-none-live';
            return $http.post(url, httpData)
                    .then(httpResponseService.getDataComplete)
                    .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(betTypeTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                betTypeTitle: betTypeTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-none-live/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                        .then(function (response) {
                            httpResponseService.saveExcelFile(response.data, fileName);
                        })
                        .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingMatchDetailService', metricGamingMatchDetailService);

    metricGamingMatchDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService', 'sportsbookMatchDetailService'];
    function metricGamingMatchDetailService($http, httpResponseService, companyWinlossService, titleService, sportsbookMatchDetailService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getMatchInformation: sportsbookMatchDetailService.getMatchInformation,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                isLive: data.isLive == undefined ? 2 : data.isLive,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                isLive: data.isLive,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingSiteService', metricGamingSiteService);

    metricGamingSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingSiteService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive == undefined ? 2 : data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameBetTypeController', NumberGameBetTypeController);

    NumberGameBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function NumberGameBetTypeController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateMatchDetail = generateMatchDetail;
        $scope.generateSite = generateSite;

        function generateMatchDetail(betType, betTypeName, isLive) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generateSite(betType, betTypeName, site, isLive) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive,
                site: site
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build([liveGridElement, nonliveGridElement], [data.Live, data.NonLive]);
                pane.data.isLive = true;
                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data.Live, true);
                }
                renderGrid(liveGridElement, data.Live, true);

                pane.data.isLive = false;
                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data.NonLive, false);
                }
                
                renderGrid(nonliveGridElement, data.NonLive, false);
                delete (pane.data.isLive);
                pane.compileAll();
            });
        }

        function renderGrid(gridElement, data, isLive) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: !isLive,
                exportExcelFunction: exportExcel
            };
            if (!isLive) {
                titleInfo.customButtons = showHideColumnBuilder.getButtonHtml();
            }

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') <= 3;
        }

        function createLinks(data, isLive) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',' + isLive + ')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\',' + isLive + ')">' + siteName + '</a>';
                }
            }
        }

        function exportExcel() {
            pane.data.isLive = true;
            var liveTitle = tab.generateBreadcrumbText();
            pane.data.isLive = false;
            var noneLiveTitle = tab.generateBreadcrumbText();
            delete (pane.data.isLive);
            pane.service.exportExcel(liveTitle, noneLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameBetTypeService', numberGameBetTypeService);

    numberGameBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'liveTitleService'];
    function numberGameBetTypeService($http, httpResponseService, companyWinlossService, liveTitleService) {
        var service = {
            getTitle: liveTitleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(liveTitle, nonLiveTitle, data, fileName) {
            var httpData = {
                liveTitle: liveTitle,
                nonLiveTitle: nonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameMatchDetailService', numberGameMatchDetailService);

    numberGameMatchDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'liveTitleService'];
    function numberGameMatchDetailService($http, httpResponseService, companyWinlossService, liveTitleService) {
        var service = {
            getTitle: liveTitleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: 161,
                isLive: data.isLive,
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: 161,
                isLive: data.isLive,
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameSiteService', numberGameSiteService);

    numberGameSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'liveTitleService'];
    function numberGameSiteService($http, httpResponseService, companyWinlossService, liveTitleService) {
        var service = {
            getTitle: liveTitleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: 161,
                isLive: data.isLive,
                betType: data.betType,
                site: data.site
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: 161,
                isLive: data.isLive,
                betType: data.betType,
                site: data.site
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('OtherSportsLiveNonLiveController', OtherSportsLiveNonLiveController);

    OtherSportsLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'sportTypeService', 'showHideColumnService'];
    function OtherSportsLiveNonLiveController($scope, $element, fanexGridService, sportTypeService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var getProductTitle = sportTypeService.getTitle;
        var getProductLiveNonLiveTitle = pane.service.getTitle;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var sportTypeGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;
        $scope.generateSportType = generateSportType;

        function generateBetType(sportType, sportTypeName) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generateSportType(isLive) {
            var data = {
                isLive: isLive
            };
            angular.extend(data, pane.data);
            tab.goForward('sportType', data);
        }

        function generate() {
            var sportTypeGridOptions,
                liveNonLiveGridOptions;
            var renderAll = function () {
                if (angular.isDefined(sportTypeGridOptions) && angular.isDefined(liveNonLiveGridOptions)) {
                    showHideColumnBuilder.build([sportTypeGridElement, liveNonLiveGridElement], [sportTypeGridOptions, liveNonLiveGridOptions]);
                    createLinksForSportType(sportTypeGridOptions);
                    renderGridForSportType(sportTypeGridOptions);
                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    renderGridForLiveNonLive(liveNonLiveGridOptions);
                    pane.compileAll();
                }
            };
            sportTypeService.getData(pane.data).then(function (data) {
                sportTypeGridOptions = data;
                renderAll();
            });
            pane.service.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
                renderAll();
            });
        }

        function renderGridForSportType(data) {
            pane.service.getTitle = getProductTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(sportTypeGridElement, true);
            sportTypeGridElement.fanexGrid(data);
        }

        function createLinksForSportType(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeName = sportTypeRow.Columns[0].Value;
                var sportType = sportTypeRow.Columns[0].CustomAttr;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportType + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }

        function renderGridForLiveNonLive(data) {
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false
            };

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(liveNonLiveGridElement, true);
            liveNonLiveGridElement.fanexGrid(data);
        }

        function createLinksForLiveNonLive(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var row = data.bodyRows[i];
                var name = row.Columns[0].Value;
                var isLive = parseInt(row.Columns[0].CustomAttr);
                row.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSportType(' + isLive + ')">' + name + '</a>';
            }
        }

        function exportExcel() {
            pane.service.getTitle = getProductTitle;
            var sportTypeTitle = tab.generateBreadcrumbText();
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            pane.service.exportExcel(sportTypeTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsLiveNonLiveService', otherSportsLiveNonLiveService);

    otherSportsLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function otherSportsLiveNonLiveService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductLiveNonLiveTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-non-live';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(sportTypeTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                sportTypeTitle: sportTypeTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-non-live/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ParlayBetTypeController', ParlayBetTypeController);

    ParlayBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'legacyService'];
    function ParlayBetTypeController($scope, $element, fanexGridService, showHideColumnService, legacyService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var parlaySportType = 9;
        var systemParlayBetType = 29;
        var mixParlayBetType = 9;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateSite = generateSite;
        $scope.viewMixParlayWindow = viewMixParlayWindow;

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function viewMixParlayWindow() {
            var url = '/WinLoss/DailyMixParlayWinLoss_2hLink/Index?startDate=' + pane.data.startDate.format('MM/DD/YYYY') + '&endDate=' + pane.data.endDate.format('MM/DD/YYYY') + '&SportId=' + parlaySportType + '&IsRedirect=true&BetType=' + mixParlayBetType;
            url = legacyService.resolveUrl(url);
            location.href = url;
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                var betTypeId = parseInt(betTypeRow.Columns[0].CustomAttr);
                if (betTypeId === systemParlayBetType) {
                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'ALL\')">' + betTypeName + '</a>';
                    for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                        var siteRow = data.bodyRows[i].SubRows[j];
                        var siteName = siteRow.Columns[0].Value;
                        siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'' + siteName+ '\')">' + siteName + '</a>';
                    }
                } else if (betTypeId === mixParlayBetType) {
                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMixParlayWindow()">' + betTypeName + '</a>';
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('parlayBetTypeService', parlayBetTypeService);

    parlayBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function parlayBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('parlaySiteService', parlaySiteService);

    parlaySiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function parlaySiteService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$element', '$scope', 'fanexGridService', 'companyWinlossService', 'productShowHideColumnService'];
    function ProductController($element, $scope, fanexGridService, companyWinlossService, productShowHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new productShowHideColumnService.Builder(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var data = {
                productName: productName
            };
            angular.extend(data, pane.data);
            var level = companyWinlossService.getTemplateSetting(productName)['product'];
            tab.goForward(level, data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                updateFooterData(data);
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productRow = data.bodyRows[i];
                var customAttr = productRow.CustomAttr;
                if (customAttr === 'product') {
                    var productName = productRow.Columns[0].Value;
                    productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProduct(\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
                }
            }
        }

        function updateFooterData(data) {
            trimNote(data);
            appendNote(data);

            function trimNote(data) {
                var footerRows = data.footerRows;
                footerRows.splice(3, footerRows.length - 3);
            }

            function appendNote(data) {
                var reportNote = "* Sportsbook Total: Sportsbook Live + Sportsbook Non-Live + Parlay + Outright" +
                                 "<br/>* Grand Total: Sportsbook Total + Number Game + Live Casino + Casino + Virtual Sports + Keno + Racing +  Bingo + Bettrade + Colossus Bets";

                var noteRow = {
                    Columns: [{
                        Name: "Main",
                        Value: reportNote,
                        MergeColNumber: 13,
                        CellAlign: "left",
                        TdClass: "grand-total-note"
                    }]
                };

                data.footerRows.push(noteRow);
            }
        }
        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('productService', productService);

    productService.$inject = ['$http', 'httpResponseService', 'titleService'];
    function productService($http, httpResponseService, titleService) {
        var service = {
            getTitle: titleService.getMainTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/product', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/product/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SoccerBetTypeController', SoccerBetTypeController);

    SoccerBetTypeController.$inject = ['$scope', '$element', 'companyWinlossService', 'fanexGridService', 'showHideColumnService', 'soccerConstants'];
    function SoccerBetTypeController($scope, $element, companyWinlossService, fanexGridService, showHideColumnService, soccerConstants) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateSite = generateSite;
        $scope.generateMatchDetail = generateMatchDetail;
        
        function buildIsHedge(betTypeName)
        {
            var isHedge = false;

            if (betTypeName && betTypeName.indexOf("(hedge)") > -1)
            {
                isHedge = true;
            }

            return isHedge;
        }

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site,
                isHedge: buildIsHedge(betTypeName),
                sportType: soccerConstants.SoccerSportType
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generateMatchDetail(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isHedge: buildIsHedge(betTypeName),
                sportType: soccerConstants.SoccerSportType
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);

                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data);
                }
                
                renderGrid(data);
                pane.compileAll();
            });
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') <= 3;
        }

        function createLinks(data) {
            var betTypeId;
            var template = companyWinlossService.getTemplate(pane.data, 'matchDetail');
            var hasDetailDrilldown = angular.isDefined(template);
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;

                if (betTypeRow.SubRows) {
                    if (hasDetailDrilldown) {
                        betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
                    }

                    for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                        var siteRow = data.bodyRows[i].SubRows[j];
                        var siteName = siteRow.Columns[0].Value;
                        siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                    }
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerBetTypeService', soccerBetTypeService);

    soccerBetTypeService.$inject = ['$http', 'httpResponseService', 'soccerConstants'];
    function soccerBetTypeService($http, httpResponseService, soccerConstants) {
        var service = {
            getTitle: getTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getTitle(data) {
            var majorMinor = buildMajorFlag(data) ? "-MAJOR" : "-MINOR";
            if (data.isLive == soccerConstants.LiveNonLive) {
                return data.productName + majorMinor + ' BET TYPES';
            }
            else {
                var liveNonLive = (data.isLive == soccerConstants.Live) ? '"LIVE"' : '"NON-LIVE"';
                return data.productName + majorMinor + " BET TYPES " + liveNonLive;
            }
        }

        function getData(data) {
            var isMajor = buildMajorFlag(data);
            var isLive = data.isLive;

            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: isLive,
                isMajor: isMajor
            };
            var url = buildUrl(isLive, isMajor);
            
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var isMajor = buildMajorFlag(data);
            var isLive = data.isLive;

            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: isLive,
                isMajor: isMajor
            };
            var url = buildUrl(isLive, isMajor) + '/excel';

            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }

        function buildMajorFlag(data)
        {
            return data.betTypeNameMajorMinor == "Soccer-Major Bet Types" ? true : false;
        }

        function buildUrl(isLive, isMajor)
        {
            var url = "api/company-win-loss/soccer/bettype";
            if (isMajor && isLive == soccerConstants.LiveNonLive) {
                url = "api/company-win-loss/soccer/sum-bettype";
            }
            else if (isMajor && isLive == soccerConstants.NonLive) {
                url = "api/company-win-loss/soccer/group-bettype";
            }

            return url;
        }
    }
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SoccerLiveNonLiveController', SoccerLiveNonLiveController);

    SoccerLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerConstants'];
    function SoccerLiveNonLiveController($scope, $element, fanexGridService, soccerConstants) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var majorMinorGridElement = angular.element(gridElements[0]);
        $scope.generate = generate;
        $scope.generateSoccerLiveNonLiveBetTypePane = generateSoccerLiveNonLiveBetTypePane;        
        pane.data.isLive = (pane.data.soccerLiveNonLive == "Soccer Non-Live") ? soccerConstants.NonLive : soccerConstants.Live;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                createLinksForMajorMinor(data);
                renderGrid(majorMinorGridElement, data);
                pane.compileLinks();
            });
        }

        function renderGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinksForMajorMinor(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLiveBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
            }
        }

        function generateSoccerLiveNonLiveBetTypePane(betTypeNameMajorMinor) {
           var data = {
                betTypeNameMajorMinor: betTypeNameMajorMinor
            };
            angular.extend(data, pane.data);

            tab.goForward('soccerBetType', data);
        }        

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerLiveNonLiveService', soccerLiveNonLiveService);

    soccerLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function soccerLiveNonLiveService($http, httpResponseService) {
        var service = {
            getTitle: getTitleWhenLiveNonLive,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;


        function getTitleWhenLiveNonLive(data, isLast) {
            return isLast ?
                data.productName + ' LIVE/NON-LIVE' :
                data.productName;
        }


        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/live-nonlive', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/live-nonlive/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerMajorMinorService', soccerMajorMinorService);

    soccerMajorMinorService.$inject = ['$http', 'httpResponseService', 'soccerConstants'];
    function soccerMajorMinorService($http, httpResponseService, soccerConstants) {
        var service = {
            getTitle: getTitleWhenMajorMinor,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getTitleWhenMajorMinor(data) {
            if (data.isLive == soccerConstants.LiveNonLive)
            {
                return data.productName;
            }
            else {
                var liveNonLive = (data.isLive == soccerConstants.Live) ? "LIVE" : "NON-LIVE";

                return data.productName + ' ' + liveNonLive;
            }
        }

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            
            return $http.post('api/company-win-loss/soccer/major-minor', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/major-minor/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerSportTypeService', soccerSportTypeService);

    soccerSportTypeService.$inject = ['$http', 'httpResponseService'];
    function soccerSportTypeService($http, httpResponseService) {
        var service = {
            exportExcel: exportExcel
        };

        return service;

        function exportExcel(majorMinorTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                majorMinorTitle: majorMinorTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/sporttype/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    var soccerConstants = {
        NonLive: 0,
        Live: 1,
        LiveNonLive: 2,
        SoccerSportType: 1
    };

    angular
        .module('app.companyWinlossApp')
        .constant('soccerConstants', soccerConstants);
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SoccerController', SoccerController);

    SoccerController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerLiveNonLiveService', 'showHideColumnService', 'soccerSportTypeService', 'soccerConstants'];
    function SoccerController($scope, $element, fanexGridService, soccerLiveNonLiveService, showHideColumnService, soccerSportTypeService, soccerConstants) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var getTitleWhenMajorMinor = pane.service.getTitle;
        var getTitleWhenLiveNonLive = soccerLiveNonLiveService.getTitle;
        var gridElements = $element.find('.freegrid');
        var majorMinorGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateSoccerLiveNonLivePane = generateSoccerLiveNonLivePane;
        $scope.generateSoccerBetTypePane = generateSoccerBetTypePane;
        pane.data.isLive = soccerConstants.LiveNonLive;
        
        function generate() {
            var majorMinorGridOptions,
                liveNonLiveGridOptions;
            var renderAll = function () {
                if (angular.isDefined(majorMinorGridOptions) && angular.isDefined(liveNonLiveGridOptions)) {
                    showHideColumnBuilder.build([majorMinorGridElement, liveNonLiveGridElement], [majorMinorGridOptions, liveNonLiveGridOptions]);
                    
                    createLinksForMajorMinor(majorMinorGridOptions);
                    renderGrid(majorMinorGridElement, majorMinorGridOptions);

                    pane.service.getTitle = getTitleWhenLiveNonLive;
                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    renderGrid(liveNonLiveGridElement, liveNonLiveGridOptions);
                    pane.service.getTitle = getTitleWhenMajorMinor;

                    pane.compileAll();
                }
            };
            pane.service.getData(pane.data).then(function (data) {
                majorMinorGridOptions = data;
                renderAll();
            });

            soccerLiveNonLiveService.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
                renderAll();
            });
        }

        function renderGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false,
                exportExcelFunction: exportExcel
            };
            if (gridElement === majorMinorGridElement) {
                titleInfo.customButtons = showHideColumnBuilder.getButtonHtml();
                titleInfo.showExcelButton = true;
            }

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinksForMajorMinor(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
            }
        }

        function generateSoccerBetTypePane(betTypeNameMajorMinor) {
            var data = {
                betTypeNameMajorMinor: betTypeNameMajorMinor
            };
            angular.extend(data, pane.data);

            tab.goForward('soccerBetType', data);
        }

        function createLinksForLiveNonLive(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var soccerLiveNonLive = betTypeRow.Columns[0].Value;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLivePane(\'' + soccerLiveNonLive + '\')">' + soccerLiveNonLive + '</a>';
            }
        }

        function generateSoccerLiveNonLivePane(soccerLiveNonLive) {
            var data = {
                soccerLiveNonLive: soccerLiveNonLive
            };
            angular.extend(data, pane.data);

            tab.goForward('soccerLiveNonLive', data);
        }

        function exportExcel() {            
            var majorMinorTitle = tab.generateBreadcrumbText();

            pane.service.getTitle = getTitleWhenLiveNonLive;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            pane.service.getTitle = getTitleWhenMajorMinor;

            soccerSportTypeService.exportExcel(majorMinorTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportsbookMatchDetailController', SportsbookMatchDetailController);

    SportsbookMatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', '$uibModal', '$uibModalStack'];
    function SportsbookMatchDetailController($scope, $element, fanexGridService, $uibModal, $uibModalStack) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.viewMatchInformation = viewMatchInformation;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function viewMatchInformation(sportType, matchId, eventDate, leagueName) {
            pane.data.sportType = sportType;
            pane.data.matchId = matchId;
            pane.data.eventDate = eventDate;
            pane.service.getMatchInformation(pane.data).then(function (data) {
                showPopup(data, leagueName);
            });
        }

        function showPopup(data, leagueName) {
            var traderName = data && data.TraderName && data.TraderName != '' ? data.TraderName : "Unassigned";
            var newScope = $scope.$new();
            angular.extend(newScope, {
                sportTypeName: pane.data.sportTypeName,
                betTypeName: pane.data.betTypeName,
                leagueName: leagueName,
                traderName: traderName,
                liveName: pane.data.isLive ? "Live!" : "Non-Live!",
                matchInformation: data.MatchInformation,
                closePopup: closePopup
            });
            $uibModal.open({
                templateUrl: 'app/company-winloss/sportsbook/sportsbook-match-information.html',
                size: 'match-information',
                scope: newScope
            });
        }
        function closePopup() {
            $uibModalStack.dismissAll("Close");
        }
        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var bodyRow = data.bodyRows[i];
                var customAttr = bodyRow.Columns[0].CustomAttr;
                if (customAttr) {
                    var matchName = bodyRow.Columns[0].Value;
                    bodyRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMatchInformation(' + customAttr + ')">' + matchName + '</a>';
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.showPager = true;
            data.pagerOption = {
                itemsPerPage: 50,
                currentPage: 0,
                itemsPerPageArray: [50, 100, 200, 500],
                totalItem: data.bodyRows.length
            };
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookMatchDetailService', sportsbookMatchDetailService);

    sportsbookMatchDetailService.$inject = ['$http', 'httpResponseService', 'titleService', 'legacyService'];
    function sportsbookMatchDetailService($http, httpResponseService, titleService, legacyService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getMatchInformation: getMatchInformation,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getMatchInformation(data) {
            var httpData = {
                matchId: data.matchId,
                betType: data.betType,
                sportType: data.sportType,
                reportDate: data.eventDate
            };

            var url = legacyService.resolveUrl('/ScoreInformation/GetScoreInformation');
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getData(data) {
            var httpData = {
                isLive: data.isLive,
                isHedge: data.isHedge,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = data.betType == 10
                ? 'api/company-win-loss/sportsbook/outright-match-detail'
                : 'api/company-win-loss/sportsbook/match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                isLive: data.isLive,
                isHedge: data.isHedge,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };

            var url = data.betType == 10
                ? 'api/company-win-loss/sportsbook/outright-match-detail/excel'
                : 'api/company-win-loss/sportsbook/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookProductViewBetTypeService', sportsbookProductViewBetTypeService);

    sportsbookProductViewBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'liveTitleService'];
    function sportsbookProductViewBetTypeService($http, httpResponseService, companyWinlossService, liveTitleService) {
        var service = {
            getTitle: liveTitleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookSiteService', sportsbookSiteService);

    sportsbookSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportsbookSiteService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isHedge: data.isHedge,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/sportsbook/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isHedge: data.isHedge,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/sportsbook/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookSportTypeViewBetTypeService', sportsbookSportTypeViewBetTypeService);

    sportsbookSportTypeViewBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportsbookSportTypeViewBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSportTypeTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive == undefined ? 2 : data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportsbookSportTypeController', SportsbookSportTypeController);

    SportsbookSportTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function SportsbookSportTypeController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(sportType, sportTypeName, isLive) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName,
                isLive: isLive
            };
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeName = sportTypeRow.Columns[0].Value;
                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookSportTypeService', sportsbookSportTypeService);

    sportsbookSportTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'liveTitleService'];
    function sportsbookSportTypeService($http, httpResponseService, companyWinlossService, liveTitleService) {
        var service = {
            getTitle: liveTitleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napPane', napPane);

    napPane.$inject = ['$templateRequest', '$compile', '$controller'];
    function napPane($templateRequest, $compile, $controller) {
        var directive = {
            restrict: 'EA',
            require: '^^napTab',
            scope: {
                pane: '='
            },
            link: link
        };
        return directive;

        function link(scope, element, attrs, tabCtrl) {
            var pane = scope.pane;
            scope.tab = tabCtrl.tab;
            $templateRequest(pane.templateUrl, true).then(function (response) {
                var templateScope = scope.$new(false);
                var templateElement = element.html(response);
                var grids = templateElement.find('.freegrid');
                angular.forEach(grids, function (grid, key) {
                    var id = 'grid_' + templateScope.$id + '_' + key;
                    $(grid).attr('id', id);
                });
                var templateCtrl = $controller(pane.controller, {
                    $scope: templateScope,
                    $element: templateElement
                });

                templateElement.data('$ngControllerController', templateCtrl);
                $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                    // save $scope & $element into pane
                    pane.$scope = scope;
                    pane.$element = templateElement;
                    pane.generate();
                });
            });
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('napPane', napPane);

    napPane.$inject = ['$log', '$compile', '$injector', 'companyWinlossService', 'showHideColumnService'];
    function napPane($log, $compile, $injector, companyWinlossService, showHideColumnService) {
        function Pane(level, data) {
            this.level = level;
            this.data = data;
            this.$scope = undefined;
            this.$element = undefined;
            this.generate = generate;
            this.show = show;
            this.compileAll = compileAll;
            this.compileLinks = compileLinks;
            this.compileDrilldown = compileDrilldown;
            this.getFileName = getFileName;

            if (angular.isUndefined(this.level) || angular.isUndefined(this.data)) {
                $log.error('Invalid pane');
                return;
            }

            var template = companyWinlossService.getTemplate(data, level);
            this.templateUrl = template.templateUrl;
            this.controller = template.controller;
            this.service = $injector.get(template.service);

            function generate() {
                this.$scope.generate();
            }

            function show() {
                var gridElement = this.$element.find('.freegrid');
                gridElement.fanexGrid('resizeGrid');
            }

            function getFileName() {
                return 'Company_Win_Loss_By_Products_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
            }

            function compileAll() {
                this.compileLinks();
                var elements = this.$element.find('.nap-component');
                $compile(elements)(this.$scope);
            }

            function compileLinks() {
                var elements = this.$element.find('.drill-down');
                $compile(elements)(this.$scope);
                elements = this.$element.find('.breadcrumb');
                $compile(elements)(this.$scope);
            }

            function compileDrilldown() {
                var elements = this.$element.find('.drill-down');
                $compile(elements)(this.$scope);
            }
        }

        return Pane;
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napTab', napTab);

    napTab.$inject = ['napPane'];
    function napTab(Pane) {
        var directive = {
            restrict: 'EA',
            scope: {
                panes: '='
            },
            templateUrl: 'app/company-winloss/tab/tab.directive.html',
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope', '$rootScope', 'napTab', 'napPane'];
    function controller($scope, $rootScope, Tab, Pane) {
        var tab = new Tab($scope.panes);
        var vm = this;
        vm.tab = tab;

        $scope.$on('nap-filter-generate', function (event, data) {
            if (tab.panes.length === 0) {
                var mainPane = new Pane('product', data);
                tab.addPane(mainPane);
            } else {
                var activePane = tab.getActivePane();
                angular.extend(activePane.data, data);
                activePane.generate();
            }
        });

        $scope.$on('nap-filter-switch', function (event) {
            tab.panes = [];
        });
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('napTab', napTab);

    napTab.$inject = ['$rootScope', 'breadcrumbService', 'napPane'];
    function napTab($rootScope, breadcrumbService, Pane) {
        function Tab(panes) {
            this.panes = angular.isDefined(panes) ? panes : [];
            this.addPane = addPane;
            this.getActivePane = getActivePane;
            this.getPreviousPane = getPreviousPane;
            this.goBack = goBack;
            this.goForward = goForward;
            this.generateBreadcrumbList = generateBreadcrumbList;
            this.generateBreadcrumbHtml = generateBreadcrumbHtml;
            this.generateBreadcrumbText = generateBreadcrumbText;

            function addPane(pane) {
                this.panes.push(pane);
            }

            function getActivePane() {
                return this.panes[this.panes.length - 1];
            }

            function getPreviousPane(pane) {
                var previousPane = null;
                for (var i = 0; i < this.panes.length; i++) {
                    var currentPane = this.panes[i];
                    if (currentPane === pane) {
                        break;
                    }

                    previousPane = currentPane;
                }

                return previousPane;
            }

            function goBack(index) {
                var activePane = this.getActivePane();
                this.panes = this.panes.slice(0, index + 1);
                var newActivePane = this.getActivePane();
                if (angular.isFunction(newActivePane.$scope.show)) {
                    newActivePane.$scope.show();
                }
                var dateRange = {
                    startDate: this.panes[index].data.startDate,
                    endDate: this.panes[index].data.endDate
                };
                $rootScope.$broadcast('nap-filter-date', dateRange);
            }

            function goForward(level, data) {
                var activePane = this.getActivePane();
                var pane = new Pane(level, data);
                this.addPane(pane);
            }

            function generateBreadcrumbList() {
                var list = [];
                for (var i = 0; i < this.panes.length; i++) {
                    var pane = this.panes[i];
                    var isLast = i === this.panes.length - 1;
                    var title = pane.service.getTitle(pane.data, isLast);
                    list.push(title);
                }

                return list;
            }

            function generateBreadcrumbHtml() {
                var list = this.generateBreadcrumbList();
                return breadcrumbService.generateHtml(list);
            }

            function generateBreadcrumbText() {
                var list = this.generateBreadcrumbList();
                return breadcrumbService.generateText(list);
            }
        }

        return Tab;
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('universalBetTypeService', universalBetTypeService);

    universalBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService', 'universalSettings'];
    function universalBetTypeService($http, httpResponseService, companyWinlossService, titleService, universalSettings) {
        var products = new Array();
        products["Bingo"] = 7;
        products["Keno"] = 8;
        products["Colossus Bets"] = 15;

        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;


        function getServiceUrl(data) {
            return data.productName == 'Bettrade'
                ? 'api/company-win-loss/bettrade'
                : 'api/company-win-loss/universal';
        }

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                productId: universalSettings.getProductId(data.productName)
            };
            var url = getServiceUrl(data) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                productId: universalSettings.getProductId(data.productName)
            };
            var url = getServiceUrl(data) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('universalSiteService', universalSiteService);

    universalSiteService.$inject = ['$http', 'httpResponseService', 'titleService'];
    function universalSiteService($http, httpResponseService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/universal/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/universal/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsRacingDetailService', virtualSportsRacingDetailService);

    virtualSportsRacingDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function virtualSportsRacingDetailService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/racing-match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/racing-match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('virtualSportsSportsbookDetailService', virtualSportsSportsbookDetailService);

    virtualSportsSportsbookDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function virtualSportsSportsbookDetailService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sportsbook-match-detail';
            return $http.post(url, httpData)
                 .then(httpResponseService.getDataComplete)
                 .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                sportType: data.sportType,
                betType: data.betType
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/sportsbook-match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();