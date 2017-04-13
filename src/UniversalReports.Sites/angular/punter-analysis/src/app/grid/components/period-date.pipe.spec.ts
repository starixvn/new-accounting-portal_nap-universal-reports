import { PeriodDatePipe } from './period-date.pipe';
import { PeriodType } from '../../filter/filter.model';

describe('PeriodDatePipe', () => {
    const pipe = new PeriodDatePipe();
    const date = new Date(2016, 10, 3);

    it('transform undefined date to empty string', () => {
        expect(pipe.transform(undefined, PeriodType.Daily)).toBe('');
    });

    it('transform undefined periodType to empty string', () => {
        expect(pipe.transform(date, undefined)).toBe('');
    });

    it('transform date to "2016-11-02" with Daily', () => {
        expect(pipe.transform(date, PeriodType.Daily)).toBe('2016-11-02');
    });

    it('transform date to "11/2016" with Monthly, MonthRange & Annually', () => {
        const expected = '11/2016';
        expect(pipe.transform(date, PeriodType.Monthly)).toBe(expected);
        expect(pipe.transform(date, PeriodType.MonthRange)).toBe(expected);
        expect(pipe.transform(date, PeriodType.Annually)).toBe(expected);
    });

    it('transform date to "11/2016 - Week 44" with Weekly', () => {
        expect(pipe.transform(date, PeriodType.Weekly)).toBe('11/2016 - Week 44');
    });
});
