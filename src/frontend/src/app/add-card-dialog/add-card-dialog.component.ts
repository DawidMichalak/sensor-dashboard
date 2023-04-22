import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SensorDetailsService } from '../dashboard/sensor-details.service';
import { SensorDetails } from '../dashboard/sensorDetails';

@Component({
  selector: 'app-add-card-dialog',
  templateUrl: './add-card-dialog.component.html',
  styleUrls: ['./add-card-dialog.component.scss'],
})
export class AddCardDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddCardDialogComponent>,
    private detailsService: SensorDetailsService
  ) {}

  sensorDetails: SensorDetails[] = [];

  ngOnInit(): void {
    this.detailsService.getData().subscribe((data) => {
      this.sensorDetails = data;
    });
  }

  name = '';
  selected = '';
}
