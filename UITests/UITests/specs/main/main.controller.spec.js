/// <reference path="../../../../sources/sites/scripts/jquery-2.1.4.min.js" />
/// <reference path="../../../../sources/sites/scripts/moment.min.js" />
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
        config,
        fakeProductWinLossData;

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
            fakeProductWinLossData = createFakeProductWinLoss("Number Game");

            function createFakeProductWinLoss(productName) {
                var winLoss = {
                    Total: { Title: productName, MemberWinLoss: 210, SMAWinLoss: 410, Commission: 30, RealIncome: 610, VirtualIncome: 810, VarianceIncome: -200, RealTurnover: 2100, VirtualTurnover: 2500, RealMargin: 0.290476, VirtualMargin: 0.324 },
                    Credit: { Title: "Credit", MemberWinLoss: 100, SMAWinLoss: 200, Commission: 10, RealIncome: 300, VirtualIncome: 400, VarianceIncome: -100, RealTurnover: 1000, VirtualTurnover: 1200, RealMargin: 0.3, VirtualMargin: 0.3 },
                    Deposit: { Title: "Deposit", MemberWinLoss: 110, SMAWinLoss: 210, Commission: 20, RealIncome: 310, VirtualIncome: 410, VarianceIncome: -100, RealTurnover: 1100, VirtualTurnover: 1300, RealMargin: 0.281818, VirtualMargin: 0.315384 }
                };

                return winLoss;
            };
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


    it('should return main report header', function () {
        var expectReportHeader = [
             { HeaderText: "Product", Width: 120, Name: "Product", HeaderAlign: "center", CellAlign: "left" },
             { HeaderText: "Member Win Loss", Width: 100, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "SMA Win Loss", Width: 100, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Commission", Width: 100, Name: "Commission", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Real", Width: 100, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Virtual", Width: 100, Name: "VirtualIncome", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Variance", Width: 100, Name: "Variance", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Real", Width: 100, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Virtual", Width: 100, Name: "VirtualTurnover", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Real", Width: 100, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right" },
             { HeaderText: "Virtual", Width: 100, Name: "VirtualMargin", HeaderAlign: "center", CellAlign: "right" }
        ];

        expect(controller.createMainReportHeader()).toEqual(expectReportHeader);
    });

    it('should return main report group header', function () {
        var expectGroupHeader = [
            { HeaderText: "Product", Name: "Product", MergeRowNumber: 2 },
            { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
            { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
            { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
            { HeaderText: "Company Income", Name: "RealIncome", MergeColNumber: 2 },
            { HeaderText: "Variance", Name: "Variance", MergeRowNumber: 2 },
            { HeaderText: "Company Turnover", Name: "RealTurnover", MergeColNumber: 2 },
            { HeaderText: "Margin", Name: "RealMargin", MergeColNumber: 2 }
        ];

        expect(controller.createMainReportGroupHeader()).toEqual(expectGroupHeader);
    });

    it('should return 11 columns when create product winloss data row', function () {
        var productWinLossDataRow = controller.createProductWinLossDataRow(fakeProductWinLossData);

        expect(productWinLossDataRow.Columns.length).toBe(11);
    });

    it('should return 2 sub rows when create data row', function () {
        var productWinLossDataRow = controller.createProductWinLossDataRow(fakeProductWinLossData);

        expect(productWinLossDataRow.SubRows.length).toBe(2);
    });

    it('should return Columns is total when create data row', function () {
        var productWinLossDataRow = controller.createProductWinLossDataRow(fakeProductWinLossData);
        var expectTotalRow = [
            { Name: "Product", Value: "Number Game" },
            { Name: "MemberWinLoss", Value: 210 },
            { Name: "SMAWinLoss", Value: 410 },
            { Name: "Commission", Value: 30 },
            { Name: "RealIncome", Value: 610 },
            { Name: "VirtualIncome", Value: 810 },
            { Name: "Variance", Value: -200 },
            { Name: "RealTurnover", Value: 2100 },
            { Name: "VirtualTurnover", Value: 2500 },
            { Name: "RealMargin", Value: 0.290476 },
            { Name: "VirtualMargin", Value: 0.324 }
        ];

        expect(productWinLossDataRow.Columns).toEqual(expectTotalRow);
    });

    it('should return first sub row is credit when create data row', function () {
        var productWinLossDataRow = controller.createProductWinLossDataRow(fakeProductWinLossData);
        var expectCreditRow = [
            { Name: "Product", Value: "Credit" },
            { Name: "MemberWinLoss", Value: 100 },
            { Name: "SMAWinLoss", Value: 200 },
            { Name: "Commission", Value: 10 },
            { Name: "RealIncome", Value: 300 },
            { Name: "VirtualIncome", Value: 400 },
            { Name: "Variance", Value: -100 },
            { Name: "RealTurnover", Value: 1000 },
            { Name: "VirtualTurnover", Value: 1200 },
            { Name: "RealMargin", Value: 0.3 },
            { Name: "VirtualMargin", Value: 0.3 }
        ];

        expect(productWinLossDataRow.SubRows[0].Columns).toEqual(expectCreditRow);
    });

    it('should return second sub row is deposit when create data row', function () {
        var productWinLossDataRow = controller.createProductWinLossDataRow(fakeProductWinLossData);
        var expectDepositRow = [
            { Name: "Product", Value: "Deposit" },
            { Name: "MemberWinLoss", Value: 110 },
            { Name: "SMAWinLoss", Value: 210 },
            { Name: "Commission", Value: 20 },
            { Name: "RealIncome", Value: 310 },
            { Name: "VirtualIncome", Value: 410 },
            { Name: "Variance", Value: -100 },
            { Name: "RealTurnover", Value: 1100 },
            { Name: "VirtualTurnover", Value: 1300 },
            { Name: "RealMargin", Value: 0.281818 },
            { Name: "VirtualMargin", Value: 0.315384 }
        ];

        expect(productWinLossDataRow.SubRows[1].Columns).toEqual(expectDepositRow);
    });
});