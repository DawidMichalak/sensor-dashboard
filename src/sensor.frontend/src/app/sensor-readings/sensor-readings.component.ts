import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions, Scale } from 'chart.js';
import Chart from 'chart.js/auto';
import 'chartjs-adapter-luxon';
import { DateTime } from 'luxon';
import { SensorDataService } from '../sensor-data.service';
import { Readings } from './readings';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.css'],
})
export class SensorReadingsComponent implements OnInit {
  constructor(private dataService: SensorDataService) {}

  @Input() public sensorData: any = {};

  public chart: Chart | undefined;
  private chartStartDate = DateTime.now().minus({ days: 2 });

  updateDateRange(newStartDate: DateTime) {
    this.dataService
      .getSelectedReadings(newStartDate, this.sensorData.sensorId)
      .subscribe((data: Readings) => {
        this.sensorData = data;
        this.chartStartDate = newStartDate;

        this.chart!.data.labels = this.sensorData.timestamps;
        this.chart!.data.datasets[0].data = this.sensorData.values;
        this.chart!.options = this.lineChartOptions();
        const opt = this.lineChartOptions();

        this.chart?.update();
      });
  }

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
      options: this.lineChartOptions(),
    });
  }

  public lineChartOptions(): ChartOptions<'line'> {
    return {
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
          min: this.chartStartDate.endOf('day').toString(),
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
}
