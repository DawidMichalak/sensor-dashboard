import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions } from "chart.js";
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.css']
})
export class SensorReadingsComponent implements OnInit{
  constructor() {}
  @Input() public sensorData:any = {};

  public chart: any;

  ngOnInit(){
    this.createChart();
  }

  createChart(){
    this.chart = new Chart("MyChart", {
      type: 'line',
      data: {
        labels: this.sensorData.timestamps, 
	       datasets: [
          {
            data: this.sensorData.values,
          },
        ]
      },
      options: this.lineChartOptions
      
    });
  }

  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    maintainAspectRatio: false
  };
}