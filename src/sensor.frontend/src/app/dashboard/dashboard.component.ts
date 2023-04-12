import { Component } from '@angular/core';
import { SensorDataService } from '../sensor-data.service';
import { Readings } from '../sensor-readings/readings';
import { SensorDetailsService } from './sensor-details.service';
import { SensorDetails } from './sensorDetails';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {
  readings: Readings[] = [];
  sensorDetails: SensorDetails[] = [];
  dataLoading: boolean = true;

  constructor(
    private dataService: SensorDataService,
    private detailsService: SensorDetailsService
  ) {}

  ngOnInit(): void {
    this.dataService.getDefaultReadings().subscribe((data: Readings[]) => {
      this.readings = data;
      this.dataLoading = false;
    });
    this.detailsService.getSensorDetails().subscribe((data) => {
      this.sensorDetails = data;
    });
  }

  GetReadingsForSensor(details: SensorDetails) {
    return this.readings.find((r) => r.sensorId === details.id);
  }
}
