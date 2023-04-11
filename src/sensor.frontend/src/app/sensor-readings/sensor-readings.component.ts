import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions, Scale } from 'chart.js';
import Chart from 'chart.js/auto';
import 'chartjs-adapter-luxon';
import { DateTime } from 'luxon';
import { SensorDataService } from '../sensor-data.service';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.css'],
})
export class SensorReadingsComponent implements OnInit {
  constructor(private dataService: SensorDataService) {}

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
        min: DateTime.now().minus({ days: 3 }).endOf('day').toString(),
        max: DateTime.now().toString(),
      },
    },
    elements: {
      point: {
        radius: 0,
      },
    },
    plugins: {
      legend: {
        display: false,
      },
    },
  };
}
