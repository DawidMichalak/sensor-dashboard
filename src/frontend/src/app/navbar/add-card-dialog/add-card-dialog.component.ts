import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CardConfiguration } from 'src/app/core/models/dashboardConfiguration';
import { DashboardConfigurationService } from 'src/app/core/api/dashboard-configuration.service';
import { SensorDetailsService } from 'src/app/core/api/sensor-details.service';
import { SensorDetails } from 'src/app/core/models/sensorDetails';

@Component({
  selector: 'app-add-card-dialog',
  templateUrl: './add-card-dialog.component.html',
  styleUrls: ['./add-card-dialog.component.scss'],
})
export class AddCardDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<AddCardDialogComponent>,
    private detailsService: SensorDetailsService,
    private configurationService: DashboardConfigurationService
  ) {}

  sensorDetails: SensorDetails[] = [];

  createForm = new FormGroup({
    name: new FormControl(''),
    sensorId: new FormControl(0, Validators.required),
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

    const createdConfiguration: Partial<CardConfiguration> = {
      name: this.createForm.value.name ?? '',
      sensorId: this.createForm.value.sensorId ?? 0,
    };

    this.configurationService.addConfigurationItem(createdConfiguration);

    this.dialogRef.close(createdConfiguration);
  }
}
