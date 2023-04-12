import { Component } from '@angular/core';
import { TimeSelectionService } from './time-selection.service';
import { Output, EventEmitter } from '@angular/core';
import { DateTime } from 'luxon';

@Component({
  selector: 'app-date-range-selection',
  templateUrl: './date-range-selection.component.html',
  styleUrls: ['./date-range-selection.component.css'],
})
export class DateRangeSelectionComponent {
  constructor(private timeService: TimeSelectionService) {}

  @Output() newStartDateEvent = new EventEmitter<DateTime>();

  chips = this.timeService.getSelectOptions();
  selectedChip: string = this.chips[1];

  onChipClicked(chip: string) {
    this.selectedChip = chip;
    this.newStartDateEvent.emit(
      this.timeService.getSelectedDate(this.selectedChip)
    );
    console.log(`Selected chip: ${chip}`);
  }
}
