/// <reference path="../../../../nap.reports.companywinloss.site/scripts/angular.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/scripts/angular-route.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/scripts/angular-mocks.js" />
/// <reference path="../../scripts/jasmine.js" />
/// <reference path="../../scripts/jasmine-html.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/app-scripts/app.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/app-scripts/values/constants.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/app-scripts/controllers/filter.js" />

describe('Controller: FilterCtrl', function () {
    var controller,
        settings;

    // load the controller's module
    beforeEach(function () {
        module('companyWinlossApp', function ($provide) {
            settings = {
                today: '2016-01-05',
                yesterday: '2016-01-04'
            };
            $provide.constant('settings', settings);
        });
    });

    // Initialize the controller and a mock scope
    beforeEach(function () {
        inject(function ($controller) {
            controller = $controller('FilterCtrl');
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

        it('the selected date is today', function () {
            expect(controller.date).toBe(settings.today);
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
            expect(controller.date).toBe(settings.today);
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
            expect(controller.date).toBe(settings.yesterday);
        });
    });
});