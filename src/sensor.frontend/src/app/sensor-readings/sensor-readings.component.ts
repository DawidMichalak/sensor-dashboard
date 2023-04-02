import { Component, OnInit } from '@angular/core';
import { SensorDataService } from '../sensor-data.service';
import { Reading } from './reading';
import { ChartConfiguration, ChartOptions, ChartType } from "chart.js";

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

  public lineChartData: ChartConfiguration<'line'>['data'] = {
    labels: [
      'January',
      'February',
      'March',
      'April',
      'May',
      'June',
      'July'
    ],
    datasets: [
      {
        data: [ 65, 59, 80, 81, 56, 55, 40 ],
        label: 'Series A',
        fill: true,
        tension: 0.5,
        borderColor: 'black',
        backgroundColor: 'rgba(255,0,0,0.3)'
      }
    ]
  };
  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    maintainAspectRatio: false
  };

}
