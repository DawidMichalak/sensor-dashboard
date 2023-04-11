import { Component } from '@angular/core';
import { TimeSelectionService } from './time-selection.service';

@Component({
  selector: 'app-date-range-selection',
  templateUrl: './date-range-selection.component.html',
  styleUrls: ['./date-range-selection.component.css'],
})
export class DateRangeSelectionComponent {
  constructor(private timeService: TimeSelectionService) {}

  chips = this.timeService.getSelectOptions();
  selectedChip: string = this.chips[0];

  onChipClicked(chip: string) {
    this.selectedChip = chip;
    console.log(`Selected chip: ${chip}`);
  }
}
