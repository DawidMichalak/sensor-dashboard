import {
  AfterContentInit,
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { ChartOptions, Scale } from 'chart.js';
import Chart from 'chart.js/auto';
import 'chartjs-adapter-luxon';
import { DateTime } from 'luxon';
import { SensorDataService } from '../sensor-data.service';
import { Readings } from './readings';
import { SensorDetails } from '../dashboard/sensorDetails';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.css'],
})
export class SensorReadingsComponent implements AfterViewInit {
  constructor(
    private dataService: SensorDataService,
    private cd: ChangeDetectorRef
  ) {}

  @Input() public sensorData: any = {};
  @Input() public sensorDetails!: SensorDetails;

  public chart: Chart | undefined;
  private chartStartDate = DateTime.now().minus({ days: 2 });

  updateDateRange(newStartDate: DateTime) {
    this.dataService
      .getSelectedReadings(newStartDate, this.sensorDetails.id)
      .subscribe((data: Readings) => {
        this.sensorData = data;
        this.chartStartDate = newStartDate;

        this.chart!.data.labels = this.sensorData.timestamps;
        this.chart!.data.datasets[0].data = this.sensorData.values;
        this.chart!.options = this.lineChartOptions();
        this.chart?.update();
      });
  }

  ngAfterViewInit(): void {
    console.log(this.sensorData, this.sensorDetails);
    if (this.sensorData) {
      this.createChart();
      this.cd.detectChanges();
    }
  }

  createChart() {
    this.chart = new Chart(`Chart${this.sensorDetails.id}`, {
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
