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
            product: 'soccerLiveNonLive',
            soccerLiveNonLive: {
                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
                controller: 'SoccerLiveNonLiveController',
                service: 'soccerLiveNonLiveService'
            },
            soccerMajorMinor: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SoccerMajorMinorController',
                service: 'soccerMajorMinorService'
            },
            soccerBetType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'soccerBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
            }
        },
        'Metric Gaming - Superlive': {
            product: 'liveNonLive',
            liveNonLive: {
                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
                controller: 'MetricGamingLiveNonLiveController',
                service: 'metricGamingLiveNonLiveService'
            },
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportsbookBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
            }
        },
        'Other Sports': {
            product: 'liveNonLive',
            liveNonLive: {
                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
                controller: 'OtherSportsLiveNonLiveController',
                service: 'otherSportsLiveNonLiveService'
            },
            sportType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'otherSportsSportTypeService'
            },
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'sportsbookBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SportsbookMatchDetailController',
                service: 'sportsbookMatchDetailService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'sportsbookSiteService'
            }
        },
        'Parlay': {
            product: 'betType',
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'ParlayBetTypeController',
                service: 'parlayBetTypeService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'parlaySiteService'
            }
        },
        'Live Casino': {
            product: 'casinoProduct',
            casinoProduct: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'CasinoProductController',
                service: 'casinoProductService'
            },
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'CasinoBetTypeService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Casino': {
            product: 'casinoProduct',
            casinoProduct: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'CasinoProductController',
                service: 'casinoProductService'
            },
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'CasinoBetTypeService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Number Game': {
            product: 'betType',
            betType: {
                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
                controller: 'NumberGameBetTypeController',
                service: 'numberGameBetTypeService'
            },
            matchDetail: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: 'numberGameMatchDetailService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'numberGameSiteService'
            }
        },
        'Virtual Sports': {
            product: 'sportType',
            sportType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'sportTypeService'
            },
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            matchDetail: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: function (data) {
                    return data.sportType >= 181 && data.sportType <= 185 ? 'virtualSportsRacingDetailService' : 'virtualSportsSportsbookDetailService';
                }
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Bettrade': {
            product: 'betType',
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'bettradeBetTypeService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        },
        'Racing': {
            product: 'sportType',
            sportType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SportTypeController',
                service: 'sportTypeService'
            },
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'betTypeService'
            },
            matchDetail: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'MatchDetailController',
                service: 'matchDetailService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'SiteController',
                service: 'siteService'
            }
        }
    };
    var universalSettings = {
        products: {
            "Bingo": 7,
            "Keno": 8,
            "Colossus Bets": 15
        },
        settings: {
            product: 'betType',
            betType: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
                controller: 'BetTypeController',
                service: 'universalBetTypeService'
            },
            site: {
                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
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
        .controller('HouseWinlossController', HouseWinlossController);

    HouseWinlossController.$inject = [];
    function HouseWinlossController() {
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
            resolveProductPath: resolveProductPath,
            resolveServiceUrl: resolveServiceUrl
        };
        return service;

        function resolveProductPath(productName) {
            if (productName == 'Live Casino' || productName == 'Casino') {
                return 'casino';
            }
            return productName.replace(/\s+/g, '-').replace(/\-+/g, '-');
        }

        function resolveServiceUrl(productName, suffix) {
            return 'api/house-win-loss-by-products/' + resolveProductPath(data.productName) + '/' + suffix;
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
                    templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
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
            getProductNumberGameTitle: getProductNumberGameTitle,
            getMatchDetailTitle: getMatchDetailTitle
        };
        return service;

        function getLiveText(isLive) {
            return ' "' + (isLive ? 'Live' : 'Non-Live') + '" ';
        }

        function getSiteText(site) {
            return '| ' + site + ' Site';
        }

        function getProductTitle(data) {
            return data.productName + getLiveText(data.isLive);
        }

        function getProductNumberGameTitle(data) {
            return data.isLive == undefined ? data.productName : data.productName + getLiveText(data.isLive);
        }

        function getSportTypeTitle(data) {
            return data.sportTypeName + getLiveText(data.isLive);
        }

        function getSiteTitle(data) {
            return data.betTypeName + getLiveText(data.isLive) + getSiteText(data.site);
        }

        function getMatchDetailTitle(data) {
            return data.betTypeName + getLiveText(data.isLive);
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
                site: site,
                isHedge: betTypeName && betTypeName.indexOf("(hedge)") > -1
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
            data.isHedge = getHedgeParameters(data.sportType, betTypeName);

            tab.goForward('matchDetail', data);

            function getHedgeParameters(sportType, betTypeName) {
                if (sportType && sportType > 1) {
                    return 2;
                }

                return betTypeName && betTypeName.indexOf("(hedge)") > -1 ? 1 : 0;
            }
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);

                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data);
                    if (pane.data.sportType == 50) {
                        createLinkChargeCom(data.footerRows);
                    }
                }

                renderGrid(data);
                pane.compileAll();
            });
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') < 3;
        }

        function createLinkChargeCom(data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].Columns[0].Value == "Charge Commission") {
                    createLink(data[i]);
                }
            }
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                createLink(data.bodyRows[i]);
            }            
        }

        function createLink(betTypeRow) {
            var template = companyWinlossService.getTemplate(pane.data, 'matchDetail');
            var hasDetailDrilldown = angular.isDefined(template);
            var betTypeName = betTypeRow.Columns[0].Value;
            var betTypeId = betTypeRow.Columns[0].CustomAttr;

            if (betTypeRow.SubRows && hasDetailDrilldown) {
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
            }
            if (betTypeRow.SubRows) {
                for (var i = 0; i < betTypeRow.SubRows.length; i++) {
                    var siteRow = betTypeRow.SubRows[i];
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
            data.bottomBorderWidth = 3;
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
        .factory('betTypeService', betTypeService);

    betTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function betTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSportTypeTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {           
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
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
            data.bottomBorderWidth = 3;
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
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail';
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
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail/excel';
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
            data.bottomBorderWidth = 3;
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
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
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
                normalMode: data.normalMode
            };
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/site/excel';
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
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.bottomBorderWidth = 3;
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
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type/excel';
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
            templateUrl: 'app/house-win-loss/filter/filter.directive.html',
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
        vm.startDate = moment.utc(config.yesterday).startOf('month');
        vm.endDate = moment.utc(config.yesterday);
        vm.generate = generate;
        vm.todayClicked = todayClicked;
        vm.yesterdayClicked = yesterdayClicked;
        vm.viewNormalMode = viewNormalMode;
        vm.viewHistoryMode = viewHistoryMode;
        vm.getDateRange = getDateRange;
        vm.updateDateRange = updateDateRange;
        $scope.$on('nap-filter-date', function (event, data) {
            updateDateRange(data);
        });

        function generate() {
            vm.dateRange = getDateRange();
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
            $('.filter-note').css('display', 'block');
            $rootScope.$broadcast('nap-filter-switch');
        }

        function viewHistoryMode() {
            vm.normalMode = false;
            $('.filter-note').css('display', 'none');
            $rootScope.$broadcast('nap-filter-switch');
        }

        function getDateRange() {
            if (vm.normalMode) {
                return {
                    normalMode: vm.normalMode,
                    startDate: vm.date,
                    endDate: vm.date
                };
            } else {
                return {
                    normalMode: vm.normalMode,
                    startDate: vm.startDate,
                    endDate: vm.endDate
                };
            }
        }

        function updateDateRange(dateRange) {
            vm.normalMode = dateRange.normalMode;
            if (vm.normalMode) {
                vm.date = dateRange.startDate;
            } else {
                vm.startDate = dateRange.startDate;
                vm.endDate = dateRange.endDate;
            }
        }
    }
})(angular);
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
                if (!defaultCollapseAllGroups) {
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
                isMajor: isMajor,
                normalMode: data.normalMode
            };
            angular.extend(httpData, data);

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
                isMajor: isMajor,
                normalMode: data.normalMode
            };
            angular.extend(httpData, data);

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
            var url = "api/house-win-loss-by-products/soccer/bettype";
            if (isMajor && isLive == soccerConstants.LiveNonLive) {
                url = "api/house-win-loss-by-products/soccer/sum-bettype";
            }
            else if (isMajor && isLive == soccerConstants.NonLive) {
                url = "api/house-win-loss-by-products/soccer/group-bettype";
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

    SoccerLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerMajorMinorService', 'soccerLiveNonLiveService', 'showHideColumnService', 'soccerConstants'];
    function SoccerLiveNonLiveController($scope, $element, fanexGridService, soccerMajorMinorService, soccerLiveNonLiveService, showHideColumnService, soccerConstants) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var getTitleWhenMajorMinor = soccerMajorMinorService.getTitle;
        var getTitleWhenLiveNonLive = pane.service.getTitle;
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
                    pane.service.getTitle = getTitleWhenMajorMinor;
                    renderGrid(majorMinorGridElement, majorMinorGridOptions);

                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    pane.service.getTitle = getTitleWhenLiveNonLive;
                    renderGrid(liveNonLiveGridElement, liveNonLiveGridOptions);

                    pane.compileAll();
                }
            };
            pane.service.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
                renderAll();
            });

            pane.service.getMajorMinorData(pane.data).then(function (data) {
                majorMinorGridOptions = data;
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
            data.bottomBorderWidth = 3;
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
                betTypeNameMajorMinor: betTypeNameMajorMinor,
                sportTypeName: betTypeNameMajorMinor
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

            tab.goForward('soccerMajorMinor', data);
        }

        function exportExcel() {

            pane.service.getTitle = getTitleWhenMajorMinor;
            var majorMinorTitle = tab.generateBreadcrumbText();

            pane.service.getTitle = getTitleWhenLiveNonLive;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            

            soccerLiveNonLiveService.exportExcel(majorMinorTitle, liveNonLiveTitle, pane.data, pane.getFileName());
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
            getMajorMinorData: getMajorMinorData,
            exportExcel: exportExcel
        };

        return service;


        function getTitleWhenLiveNonLive(data, isLast) {
            return isLast ?
                data.productName + ' LIVE/NON-LIVE' :
                data.productName;
        }


        function getData(data) {
            return $http.post('api/house-win-loss-by-products/soccer/live-nonlive', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getMajorMinorData(data) {
            return $http.post('api/house-win-loss-by-products/soccer/major-minor', data)
                            .then(httpResponseService.getDataComplete)
                            .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(majorMinorTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                majorMinorTitle: majorMinorTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            return $http.post('api/house-win-loss-by-products/soccer/live-nonlive/excel', httpData, { responseType: "arraybuffer" })
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
        .controller('SoccerMajorMinorController', SoccerMajorMinorController);

    SoccerMajorMinorController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerConstants', 'showHideColumnService'];
    function SoccerMajorMinorController($scope, $element, fanexGridService, soccerConstants, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var majorMinorGridElement = angular.element(gridElements[0]);
        $scope.generate = generate;
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generateSoccerLiveNonLiveBetTypePane = generateSoccerLiveNonLiveBetTypePane;
        pane.data.isLive = (pane.data.soccerLiveNonLive == "Soccer Non-Live") ? soccerConstants.NonLive : soccerConstants.Live;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElements, data);
                createLinksForMajorMinor(data);
                renderGrid(gridElements, data);
                pane.compileAll();
            });
        }

        function renderGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.bottomBorderWidth = 3;
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
                betTypeNameMajorMinor: betTypeNameMajorMinor,
                sportTypeName: betTypeNameMajorMinor
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
                return data.productName + ' ' + "MAJOR/MINOR";
            }
            else {
                var liveNonLive = (data.isLive == soccerConstants.Live) ? "LIVE" : "NON-LIVE";

                return data.productName + ' ' + liveNonLive;
            }
        }

        function getData(data) {            
            return $http.post('api/house-win-loss-by-products/soccer/major-minor', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            return $http.post('api/house-win-loss-by-products/soccer/major-minor/excel', httpData, { responseType: "arraybuffer" })
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
                return 'House_Win_Loss_By_Products_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
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
            templateUrl: 'app/house-win-loss/tab/tab.directive.html',
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

                activePane = this.panes[index];
                var dateRange = {
                    normalMode: activePane.data.normalMode,
                    startDate: activePane.data.startDate,
                    endDate: activePane.data.endDate
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