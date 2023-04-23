import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SensorDetailsService } from '../dashboard/sensor-details.service';
import { SensorDetails } from '../shared/sensorDetails';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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

  createForm = new FormGroup({
    name: new FormControl(''),
    sensor: new FormControl('', Validators.required),
  });

  ngOnInit(): void {
    this.detailsService.getData().subscribe((data) => {
      this.sensorDetails = data;
    });
  }

  onSubmit(): void {
    if (this.createForm.invalid) {
      return;
    }
    console.log(this.createForm.value);
    this.dialogRef.close();
  }
}
