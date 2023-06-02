import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SensorDetails } from 'src/app/core/models/sensorDetails';

@Component({
  selector: 'app-edit-sensor',
  templateUrl: './edit-sensor.component.html',
  styleUrls: ['./edit-sensor.component.scss'],
})
export class EditSensorComponent {
  constructor(
    public dialogRef: MatDialogRef<EditSensorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SensorDetails
  ) {}

  sensorForm = new FormGroup({
    sensorId: new FormControl(this.data.id, Validators.required),
    name: new FormControl(this.data.name, Validators.required),
  });

  onSubmit(): void {
    if (this.sensorForm.invalid) {
      return;
    }

    const sensorDetails: SensorDetails = {
      id: this.sensorForm.value.sensorId ?? 0,
      name: this.sensorForm.value.name ?? '',
    };

    this.dialogRef.close(sensorDetails);
  }
}
