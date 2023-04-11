import { Component } from '@angular/core';
import { SensorDataService } from '../sensor-data.service';
import { Readings } from '../sensor-readings/readings';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent {
  readings: Readings[] = [];

  constructor(private dataService: SensorDataService) {}

  ngOnInit(): void {
    this.dataService.getDefaultReadings().subscribe((data: Readings[]) => {
      this.readings = data;
    });
  }
}
