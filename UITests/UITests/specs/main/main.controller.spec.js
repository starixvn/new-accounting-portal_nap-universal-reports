/// <reference path="../../../../sources/sites/scripts/jquery-2.1.4.min.js" />
/// <reference path="../../../../sources/sites/scripts/moment.min.js" />
/// <reference path="../../../../sources/sites/scripts/fanex.grid.js" />
/// <reference path="../../../../sources/sites/scripts/angular.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-route.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-mocks.js" />
/// <reference path="../../scripts/jasmine.js" />
/// <reference path="../../scripts/jasmine-html.js" />
/// <reference path="../../../../sources/sites/scripts/angular-moment.min.js" />
/// <reference path="../../../../sources/sites/app/app.js" />
/// <reference path="../../../../sources/sites/app/app.config.js" />
/// <reference path="../../../../sources/sites/app/common/logger.js" />
/// <reference path="../../../../sources/sites/app/main/main.service.js" />
/// <reference path="../../../../sources/sites/app/main/main.controller.js" />

describe('Controller: MainController', function () {
    var scope,
        controller,
        config,
        formatStrings,
        httpBackend;

    // load the controller's module
    beforeEach(module('companyWinlossApp'));

    // Initialize the controller and a mock scope
    beforeEach(inject(function ($rootScope, $controller, $q, $injector, $httpBackend) {
        scope = $rootScope.$new();
        config = {
            today: new Date(2016, 0, 5),
            yesterday: new Date(2016, 0, 4)
        };
        formatStrings = $injector.get('formatStrings');
        httpBackend = $httpBackend;
        setupFakeHttpRequests();
        controller = $controller('MainController', {
            $scope: scope,
            config: config
        });

        function setupFakeHttpRequests() {
            var mockData = createFakeProductWinLoss("NumberGame");
            httpBackend.whenPOST('/api/productwinloss/values').respond(mockData);
        }

        function createFakeProductWinLoss(productName) {
            var winLoss = {
                Total: { Title: productName, MemberWinLoss: 210, SMAWinLoss: 410, Commission: 30, RealIncome: 610, VirtualIncome: 810, VarianceIncome: -200, RealTurnover: 2100, VirtualTurnover: 2500, RealMargin: 0.290476, VirtualMargin: 0.324 },
                Credit: { Title: "Credit", MemberWinLoss: 100, SMAWinLoss: 200, Commission: 10, RealIncome: 300, VirtualIncome: 400, VarianceIncome: -100, RealTurnover: 1000, VirtualTurnover: 1200, RealMargin: 0.3, VirtualMargin: 0.3 },
                Deposit: { Title: "Deposit", MemberWinLoss: 110, SMAWinLoss: 210, Commission: 20, RealIncome: 310, VirtualIncome: 410, VarianceIncome: -100, RealTurnover: 1100, VirtualTurnover: 1300, RealMargin: 0.281818, VirtualMargin: 0.315384 }
            };

            return winLoss;
        };
    }));

    it('should be created successfully', function () {
        expect(controller).toBeDefined();
    });

    describe('after the form is loaded', function () {
        it('the current mode is normal', function () {
            expect(controller.normalMode).toBe(true);
        });

        it('the selected date is today', function () {
            expect(controller.date).toBe(config.today);
        });
    });

    describe('after the button today is clicked', function () {
        it('the selected date is today', function () {
            controller.todayClicked();
            expect(controller.date).toBe(config.today);
        });
    });

    describe('after the button yesterday is clicked', function () {
        it('the selected date is yesterday', function () {
            controller.yesterdayClicked();
            expect(controller.date).toBe(config.yesterday);
        });
    });

    describe('after the button history is clicked', function () {
        it('the current mode is history', function () {
            controller.viewHistoryMode();
            expect(controller.normalMode).toBe(false);
        });
    });

    describe('after the button back is clicked', function () {
        it('the current mode is normal', function () {
            controller.viewNormalMode();
            expect(controller.normalMode).toBe(true);
        });
    });

    describe('after the button generate is clicked', function () {
        it('data is available', function () {
            controller.data = undefined;
            controller.generate();
            httpBackend.flush();
            expect(controller.data).toBeDefined();
        });

        it('title of grid is Normal if current mode is normal', function () {
            controller.normalMode = true;
            controller.generate();
            httpBackend.flush();
            expect(controller.data.Total.Title).toBe('Normal');
        });

        it('title of grid is History if current mode is history', function () {
            controller.normalMode = false;
            controller.generate();
            httpBackend.flush();
            expect(controller.data.Total.Title).toBe('History');
        });
    });

    afterEach(function () {
        httpBackend.verifyNoOutstandingExpectation();
    })
});