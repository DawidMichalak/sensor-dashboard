import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TimeSelectionService {
  constructor() {}
  private timeMap = new Map<string, number>([
    ['24 HOURS', 1],
    ['2 DAYS', 2],
    ['WEEK', 7],
  ]);

  getSelectOptions() {
    return Array.from(this.timeMap.keys());
  }
}
