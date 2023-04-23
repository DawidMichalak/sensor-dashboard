import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  Input,
} from '@angular/core';
import { ChartOptions } from 'chart.js';
import Chart from 'chart.js/auto';
import 'chartjs-adapter-luxon';
import { DateTime } from 'luxon';
import { SensorDataService } from '../sensor-data.service';
import { Readings } from '../shared/readings';
import { SensorDetails } from '../shared/sensorDetails';
import { CardConfiguration } from '../shared/dashboardConfiguration';

@Component({
  selector: 'app-sensor-readings',
  templateUrl: './sensor-readings.component.html',
  styleUrls: ['./sensor-readings.component.scss'],
})
export class SensorReadingsComponent implements AfterViewInit {
  constructor(
    private dataService: SensorDataService,
    private cd: ChangeDetectorRef
  ) {}

  @Input() public sensorData: Readings | undefined;
  @Input() public cardConfiguration!: CardConfiguration;

  public chart!: Chart;
  private chartStartDate = DateTime.now().minus({ days: 2 });

  updateDateRange(newStartDate: DateTime) {
    this.dataService
      .getSelectedReadings(newStartDate, this.cardConfiguration.sensorId)
      .subscribe((data: Readings) => {
        this.sensorData = data;
        this.chartStartDate = newStartDate;

        if (this.sensorData) {
          this.chart.data.labels = this.sensorData.timestamps;
          this.chart.data.datasets[0].data = this.sensorData.values;
        }
        this.chart.options = this.lineChartOptions();
        this.chart.update();
      });
  }

  ngAfterViewInit(): void {
    this.createChart();
    this.cd.detectChanges();
  }

  createChart() {
    this.chart = new Chart(`Chart${this.cardConfiguration.sensorId}`, {
      type: 'line',
      data: {
        labels: this.sensorData?.timestamps,
        datasets: [
          {
            label: 'Temperature',
            borderColor: '#00609E',
            data: this.sensorData?.values ?? [],
            tension: 0.1,
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
          min: this.chartStartDate.endOf('hour').toString(),
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
      animations: {
        x: {
          duration: 0,
        },
      },
    };
  }
}
