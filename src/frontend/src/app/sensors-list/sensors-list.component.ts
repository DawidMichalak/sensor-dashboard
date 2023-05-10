import { Component, OnInit } from '@angular/core';
import { SensorDetailsService } from '../core/api/sensor-details.service';
import { SensorDetails } from '../core/models/sensorDetails';
import { MatTableDataSource } from '@angular/material/table';
import { DataSource } from '@angular/cdk/collections';
import { ReplaySubject, Observable } from 'rxjs';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-sensors-list',
  templateUrl: './sensors-list.component.html',
  styleUrls: ['./sensors-list.component.scss'],
})
export class SensorsListComponent {
  constructor(private detailsService: SensorDetailsService) {}
  ngOnInit() {
    this.detailsService.getData().subscribe((data) => {
      this.datasource = new MatTableDataSource<SensorDetails>(data);
    });
  }

  datasource: MatTableDataSource<SensorDetails> = new MatTableDataSource();
  displayedColumns: string[] = ['name', 'rename', 'delete'];
}
