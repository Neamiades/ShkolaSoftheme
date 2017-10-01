import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'bytes'
})
export class BytesPipe implements PipeTransform {
    transform(val: number, field?: string): number | string {
        const measurements = ['bytes', 'KB', 'MB', 'GB', 'TB', 'PB'];
        let measurement: string;
        let unit = 0;

        while (val >= 1000) {
            val /= 1000;
            unit++;
        }

        if (field === 'value') {
            val = unit > 1 ? val : 0;
            const res = val % 100 < 1 ? Math.round(val * 100) / 100 : Math.round(val * 10) / 10;
            return res;

        } else if (field === 'measurement') {
            measurement = unit > 1 ? measurements[unit] : 'MB';
            return measurement;

        } else {
            const value = val % 100 < 1 ? Math.round(val * 100) / 100 : Math.round(val * 10) / 10;
            const res = unit > 1 ? `${value} ${measurements[unit]}` : '0 MB';
            return res;
        }
    }
}
