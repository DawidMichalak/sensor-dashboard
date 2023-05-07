import { Component } from '@angular/core';
import { SensorDataService } from '../core/api/sensor-data.service';
import { DashboardConfigurationService } from '../core/api/dashboard-configuration.service';
import { CardConfiguration } from '../core/models/dashboardConfiguration';
import { Readings } from '../core/models/readings';
import { SensorDetails } from '../core/models/sensorDetails';
import { SensorDetailsService } from '../core/api/sensor-details.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent {
  readings: Readings[] = [];
  sensorDetails: SensorDetails[] = [];
  configurations: CardConfiguration[] = [];
  dataLoading: boolean = true;

  constructor(
    private dataService: SensorDataService,
    private detailsService: SensorDetailsService,
    private configurationService: DashboardConfigurationService
  ) {}

  ngOnInit(): void {
    this.dataService.getDefaultReadings().subscribe((data: Readings[]) => {
      this.readings = data;
      this.dataLoading = false;
    });
    this.detailsService.getData().subscribe((data) => {
      this.sensorDetails = data;
    });
    this.configurationService.getConfiguration().subscribe((data) => {
      this.configurations = data;
    });
  }

  getReadingsForSensor(id: number) {
    return this.readings.find((r) => r.sensorId === id);
  }
}
