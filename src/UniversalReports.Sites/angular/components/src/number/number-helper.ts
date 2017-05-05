import { NumberFormat } from './number-format';

export let NumberHelper = {
    format: format
};

const decimalFormat = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
});

const integerFormat = new Intl.NumberFormat('en-US', {
    style: 'decimal',
    minimumFractionDigits: 0,
    maximumFractionDigits: 0
});

const percentFormat = new Intl.NumberFormat('en-US', {
    style: 'percent',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
});

function format(input: number, format: NumberFormat) {
    switch (format) {
        case NumberFormat.Integer:
            return integerFormat.format(input);
        case NumberFormat.Decimal:
            return decimalFormat.format(input);
        case NumberFormat.Percent:
            return percentFormat.format(input);
    }
}
