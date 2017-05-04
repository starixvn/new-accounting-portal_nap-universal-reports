import * as numeral from 'numeral';

export class RomanFormatter {
    private saveOutputs: string[] = [];
    private formatStrings = ['0 a', '0.0 a', '0.00 a', '0.000 a'];

    format(value: number) {
        let output = '';
        for (let i = 0; i < this.formatStrings.length; i++) {
            output = numeral(value).format(this.formatStrings[i]);
            if (this.saveOutputs.indexOf(output) === -1) {
                this.saveOutputs.push(output);
                return output;
            }
        }

        return output;
    }
}
