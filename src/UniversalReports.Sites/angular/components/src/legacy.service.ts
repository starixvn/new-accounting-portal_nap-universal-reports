import { Injectable } from '@angular/core';
import { Config } from './config';

@Injectable()
export class LegacyService {
    resolveUrl(url: string): string {
        return this.isUniversalUrl(url)
            ? url
            : Config.legacyPath + url;
    }

    isUniversalUrl(url: string): boolean {
        return url.indexOf('/UniversalReports') === 0;
    }
}
