import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions, Scale } from 'chart.js';
import Chart from 'chart.js/auto';
import 'chartjs-adapter-luxon';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.css'],
})
export class SensorReadingsComponent implements OnInit {
  constructor() {}
  @Input() public sensorData: any = {};

  public chart: any;

  ngOnInit() {
    this.createChart();
  }

  createChart() {
    this.chart = new Chart('MyChart', {
      type: 'line',
      data: {
        labels: this.sensorData.timestamps,
        datasets: [
          {
            label: 'Temperature',
            borderColor: '#00609E',
            data: this.sensorData.values,
          },
        ],
      },
      options: this.lineChartOptions,
    });
  }

  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    maintainAspectRatio: false,
    scales: {
      x: {
        type: 'time',
        ticks: {
          major: {
            enabled: true,
          },
          font: (ctx) => {
            const weight = ctx.tick && ctx.tick.major ? 'bold' : '';
            return { weight: weight };
          },
        },
        time: {
          unit: 'hour',
          displayFormats: { hour: 'HH:mm' },
        },
      },
    },
  };
}
