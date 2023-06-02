import { Component, OnInit } from '@angular/core';
import { SensorDetailsService } from '../../core/api/sensor-details.service';
import { SensorDetails } from '../../core/models/sensorDetails';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteDialogComponent } from '../../shared/delete-dialog/delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { EditSensorComponent } from './edit-sensor/edit-sensor.component';

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
export class SensorsListComponent implements OnInit {
  constructor(
    private detailsService: SensorDetailsService,
    public dialog: MatDialog
  ) {}
  ngOnInit() {
    this.detailsService.getData().subscribe((data) => {
      this.datasource = new MatTableDataSource<SensorDetails>(data);
    });
  }

  datasource: MatTableDataSource<SensorDetails> = new MatTableDataSource();
  displayedColumns: string[] = ['name', 'rename', 'delete'];

  openDeleteDialog(id: number): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      data: { itemName: 'sensor' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.detailsService.deleteSensorDetails(id);
      }
    });
  }

  openEditDialog(sensor?: SensorDetails): void {
    const dialogRef = this.dialog.open(EditSensorComponent, {
      data: sensor,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        if (sensor === undefined) {
          this.detailsService.addSensor(result);
        } else {
          this.detailsService.updateSensorDetails(result);
        }
      }
    });
  }
}
