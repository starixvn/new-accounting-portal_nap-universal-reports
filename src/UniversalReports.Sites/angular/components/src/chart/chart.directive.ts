import {
    OnDestroy,
    OnInit,
    OnChanges,
    EventEmitter,
    ElementRef,
    Input,
    Output,
    SimpleChanges,
    Directive
} from '@angular/core';

declare var Chart: any;

// private helper functions
interface Color {
    backgroundColor?: string | string[];
    borderWidth?: number | number[];
    borderColor?: string | string[];
    borderCapStyle?: string;
    borderDash?: number[];
    borderDashOffset?: number;
    borderJoinStyle?: string;

    pointBorderColor?: string | string[];
    pointBackgroundColor?: string | string[];
    pointBorderWidth?: number | number[];

    pointRadius?: number | number[];
    pointHoverRadius?: number | number[];
    pointHitRadius?: number | number[];

    pointHoverBackgroundColor?: string | string[];
    pointHoverBorderColor?: string | string[];
    pointHoverBorderWidth?: number | number[];
    pointStyle?: string | string[];

    hoverBackgroundColor?: string | string[];
    hoverBorderColor?: string | string[];
    hoverBorderWidth?: number;
}

// pie | doughnut
interface Colors extends Color {
    data?: number[];
    label?: string;
}

function rgba(colour: Array<number>, alpha: number): string {
    return 'rgba(' + colour.concat(alpha).join(',') + ')';
}

function getRandomInt(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function formatLineColor(colors: Array<number>): Color {
    return {
        backgroundColor: rgba(colors, 1),
        borderColor: rgba(colors, 1),
        pointBackgroundColor: rgba(colors, 1),
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: rgba(colors, 1)
    };
}

function formatBarColor(colors: Array<number>): Color {
    return {
        backgroundColor: rgba(colors, 1),
        borderColor: rgba(colors, 1),
        hoverBackgroundColor: rgba(colors, 1),
        hoverBorderColor: rgba(colors, 1)
    };
}

function formatPieColors(colors: Array<number[]>): Colors {
    return {
        backgroundColor: colors.map((color: number[]) => rgba(color, 1)),
        borderColor: colors.map(() => '#fff'),
        pointBackgroundColor: colors.map((color: number[]) => rgba(color, 1)),
        pointBorderColor: colors.map(() => '#fff'),
        pointHoverBackgroundColor: colors.map((color: number[]) => rgba(color, 1)),
        pointHoverBorderColor: colors.map((color: number[]) => rgba(color, 1))
    };
}

function formatPolarAreaColors(colors: Array<number[]>): Color {
    return {
        backgroundColor: colors.map((color: number[]) => rgba(color, 1)),
        borderColor: colors.map((color: number[]) => rgba(color, 1)),
        hoverBackgroundColor: colors.map((color: number[]) => rgba(color, 1)),
        hoverBorderColor: colors.map((color: number[]) => rgba(color, 1))
    };
}

function getRandomColor(): number[] {
    return [getRandomInt(0, 255), getRandomInt(0, 255), getRandomInt(0, 255)];
}

/**
 * Generate colors for line|bar charts
 * @param index
 * @returns {number[]|Color}
 */
function generateColor(index: number): number[] {
    return ChartDirective.defaultColors[index] || getRandomColor();
}

/**
 * Generate colors for pie|doughnut charts
 * @param count
 * @returns {Colors}
 */
function generateColors(count: number): Array<number[]> {
    const colorsArr: Array<number[]> = new Array(count);
    for (let i = 0; i < count; i++) {
        colorsArr[i] = ChartDirective.defaultColors[i] || getRandomColor();
    }
    return colorsArr;
}

/**
 * Generate colors by chart type
 * @param chartType
 * @param index
 * @param count
 * @returns {Color}
 */
function getColors(chartType: string, index: number, count: number): Color {
    if (chartType === 'pie' || chartType === 'doughnut') {
        return formatPieColors(generateColors(count));
    }

    if (chartType === 'polarArea') {
        return formatPolarAreaColors(generateColors(count));
    }

    if (chartType === 'line' || chartType === 'radar') {
        return formatLineColor(generateColor(index));
    }

    if (chartType === 'bar' || chartType === 'horizontalBar') {
        return formatBarColor(generateColor(index));
    }
    return generateColor(index);
}

@Directive({
    selector: 'canvas[napChart]',
    exportAs: 'base-chart'
})
export class ChartDirective implements OnDestroy, OnChanges, OnInit {
    static defaultColors: Array<number[]> = [
        [19, 73, 128],
        [135, 61, 135],
        [69, 225, 36],
        [225, 107, 11],
        [65, 72, 222],
        [211, 18, 28],
        [255, 32, 77],
        [83, 176, 238],
        [64, 0, 128],
        [185, 122, 87],
        [255, 99, 132],
        [241, 86, 94],
        [133, 133, 133],
        [128, 133, 233],
        [56, 165, 162],
        [255, 183, 13]
    ];

    @Input() data: number[] | any[];
    @Input() datasets: any[];
    @Input() labels: Array<any> = [];
    @Input() options: any = {};
    @Input() chartType: string;
    @Input() colors: Array<any>;
    @Input() legend: boolean;

    @Output() chartClick: EventEmitter<any> = new EventEmitter();
    @Output() chartHover: EventEmitter<any> = new EventEmitter();

    ctx: any;
    chart: any;
    element: ElementRef;
    private cvs: any;
    private initFlag = false;

    constructor(element: ElementRef) {
        this.element = element;
    }

    ngOnInit() {
        this.ctx = this.element.nativeElement.getContext('2d');
        this.cvs = this.element.nativeElement;
        this.initFlag = true;
        if (this.data || this.datasets) {
            this.refresh();
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (this.initFlag) {
            // Check if the changes are in the data or datasets
            if (changes.hasOwnProperty('data') || changes.hasOwnProperty('datasets')) {
                if (changes['data']) {
                    this.updateChartData(changes['data'].currentValue);
                } else {
                    this.updateChartData(changes['datasets'].currentValue);
                }

                this.chart.update();
            } else {
                // otherwise rebuild the chart
                this.refresh();
            }
        }
    }

    ngOnDestroy() {
        if (this.chart) {
            this.chart.destroy();
            this.chart = void 0;
        }
    }

    private getChartBuilder(ctx: any/*, data:Array<any>, options:any*/) {
        const datasets: any = this.getDatasets();
        const options: any = Object.assign({}, this.options);
        if (this.legend === false) {
            options.legend = { display: false };
        }
        // hock for onHover and onClick events
        options.hover = options.hover || {};
        if (!options.hover.onHover) {
            options.hover.onHover = (active: Array<any>) => {
                if (active && !active.length) {
                    return;
                }
                this.chartHover.emit({ active });
            };
        }

        if (!options.onClick) {
            options.onClick = (event: any, active: Array<any>) => {
                this.chartClick.emit({ event, active });
            };
        }

        const opts = {
            type: this.chartType,
            data: {
                labels: this.labels,
                datasets: datasets
            },
            options: options
        };

        if (typeof Chart === 'undefined') {
            throw new Error('ng2-charts configuration issue: Embedding Chart.js lib is mandatory');
        }

        return new Chart(ctx, opts);
    }

    private updateChartData(newDataValues: number[] | any[]) {
        if (Array.isArray(newDataValues[0].data)) {
            this.chart.data.datasets.forEach((dataset: any, i: number) => {
                dataset.data = newDataValues[i].data;

                if (newDataValues[i].label) {
                    dataset.label = newDataValues[i].label;
                }
            });
        } else {
            this.chart.data.datasets[0].data = newDataValues;
        }
    }

    private getDatasets(): any {
        let datasets: any = void 0;
        // in case if datasets is not provided, but data is present
        if (!this.datasets || !this.datasets.length && (this.data && this.data.length)) {
            if (Array.isArray(this.data[0])) {
                datasets = (this.data as Array<number[]>).map((data: number[], index: number) => {
                    return { data, label: this.labels[index] || `Label ${index}` };
                });
            } else {
                datasets = [{ data: this.data, label: `Label 0` }];
            }
        }

        if (this.datasets && this.datasets.length ||
            (datasets && datasets.length)) {
            datasets = (this.datasets || datasets)
                .map((elm: number, index: number) => {
                    const newElm: any = Object.assign({}, elm);
                    if (this.colors && this.colors.length) {
                        Object.assign(newElm, this.colors[index]);
                    } else {
                        Object.assign(newElm, getColors(this.chartType, index, newElm.data.length));
                    }
                    return newElm;
                });
        }

        if (!datasets) {
            throw new Error(`ng-charts configuration error,
      data or datasets field are required to render char ${this.chartType}`);
        }

        return datasets;
    }

    private refresh() {
        // if (this.options && this.options.responsive) {
        //   setTimeout(() => this.refresh(), 50);
        // }

        // todo: remove this line, it is producing flickering
        this.ngOnDestroy();
        this.chart = this.getChartBuilder(this.ctx/*, data, this.options*/);
    }
}
