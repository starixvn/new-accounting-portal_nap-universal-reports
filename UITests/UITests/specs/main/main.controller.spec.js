/// <reference path="../../../../sources/sites/scripts/angular.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-route.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-mocks.js" />
/// <reference path="../../scripts/jasmine.js" />
/// <reference path="../../scripts/jasmine-html.js" />
/// <reference path="../../../../sources/sites/app/app.js" />
/// <reference path="../../../../sources/sites/app/app.config.js" />
/// <reference path="../../../../sources/sites/app/main/main.controller.js" />

describe('Controller: MainController', function () {
    var controller,
        settings;

    // load the controller's module
    beforeEach(function () {
        module('companyWinlossApp', function ($provide) {
            config = {
                today: new Date(2016, 0, 5),
                yesterday: new Date(2016, 0, 4)
            };
            $provide.constant('config', config);
        });
    });

    // Initialize the controller and a mock scope
    beforeEach(function () {
        inject(function ($controller) {
            controller = $controller('MainController');
        });
    });

    it('should be created successfully', function () {
        expect(controller).toBeDefined();
    });

    describe('after the form is loaded', function () {
        it('the button export and expand are disable', function () {
            expect(controller.disableExport).toBe(true);
            expect(controller.disableExpand).toBe(true);
        });

        it('the current mode is normal', function () {
            expect(controller.normalMode).toBe(true);
        });

        it('the selected date is today', function () {
            expect(controller.date).toBe(config.today);
        });
    });

    describe('after the button generate is clicked', function () {
        it('the button export and expand are enable', function () {
            controller.generate();
            expect(controller.disableExport).toBe(false);
            expect(controller.disableExpand).toBe(false);
        });
    });

    describe('after the button today is clicked', function () {
        it('the button export and expand are enable', function () {
            controller.todayClicked();
            expect(controller.disableExport).toBe(false);
            expect(controller.disableExpand).toBe(false);
        });

        it('the selected date is today', function () {
            controller.todayClicked();
            expect(controller.date).toBe(config.today);
        });
    });

    describe('after the button yesterday is clicked', function () {
        it('the button export and expand are enable', function () {
            controller.yesterdayClicked();
            expect(controller.disableExport).toBe(false);
            expect(controller.disableExpand).toBe(false);
        });

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
});