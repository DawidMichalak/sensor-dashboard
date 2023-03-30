import { Component, OnInit } from '@angular/core';
import { SensorDataService } from '../sensor-data.service';
import { Reading } from './reading';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.css']
})
export class SensorReadingsComponent implements OnInit{

  readings: Reading[] = [];

  constructor(private dataService: SensorDataService) {}
  
  ngOnInit(): void {
    this.dataService.getReadings().subscribe(readings => this.readings = readings);
  }
}
