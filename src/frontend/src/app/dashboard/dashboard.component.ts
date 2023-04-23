import { Component } from '@angular/core';
import { SensorDataService } from '../sensor-data.service';
import { Readings } from '../shared/readings';
import { SensorDetailsService } from './sensor-details.service';
import { SensorDetails } from '../shared/sensorDetails';
import { DashboardConfigurationService } from '../dashboard-configuration.service';
import { CardConfiguration } from '../shared/dashboardConfiguration';

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
