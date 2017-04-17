import { NgbDateStruct } from '../date-model';
import { DateParserFormatter } from './date-parser-formatter';

describe('DateParserFormatter', () => {
    const formatter = new DateParserFormatter('longDate');

    describe('format', () => {
        it('should format a null input to empty string', () => {
            expect(formatter.format(null)).toBe('');
        });

        it('should format a valid input to formatted string', () => {
            const date: NgbDateStruct = { year: 2016, month: 11, day: 2 };
            expect(formatter.format(date)).toBe('November 2, 2016');
        });
    });

    describe('parse', () => {
        it('should parse a undefined input to null', () => {
            expect(formatter.parse(undefined)).toBe(null);
        });

        it('should parse a null input to null', () => {
            expect(formatter.parse(null)).toBe(null);
        });

        it('should parse a empty input to null', () => {
            expect(formatter.parse('')).toBe(null);
        });

        it('should parse an invalid input to null', () => {
            expect(formatter.parse('ABC')).toBe(null);
        });

        it('should parse a valid input to valid object', () => {
            const dateStruct = formatter.parse('November 2, 2016');
            const expectedDate: NgbDateStruct = { year: 2016, month: 11, day: 2 };
            expect(dateStruct).toEqual(expectedDate);
        });
    });
});
