import { Injectable } from '@angular/core';
import { DateTime } from 'luxon';

@Injectable({
  providedIn: 'root',
})
export class TimeSelectionService {
  constructor() {}

  private timeMap = new Map<string, number>([
    ['24 HOURS', 1],
    ['48 HOURS', 2],
    ['1 WEEK', 7],
  ]);

  getSelectOptions() {
    return Array.from(this.timeMap.keys());
  }

  getSelectedDate(selectedKey: string): DateTime {
    const daysOffset = this.timeMap.get(selectedKey) ?? 2;
    return DateTime.now().minus({ days: daysOffset });
  }
}
