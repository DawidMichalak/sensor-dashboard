import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RenameDialogComponent } from './rename-dialog/rename-dialog.component';
import { SensorDetailsService } from 'src/app/dashboard/sensor-details.service';
import { SensorDetails } from 'src/app/dashboard/sensorDetails';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-readings-menu',
  templateUrl: './readings-menu.component.html',
  styleUrls: ['./readings-menu.component.scss'],
})
export class ReadingsMenuComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    private detailsService: SensorDetailsService
  ) {}
  @Input() public sensorId!: number;

  private sensorDetails!: SensorDetails[];
  private detailsIndex: number | undefined;

  ngOnInit(): void {
    this.detailsService.getData().subscribe((data) => {
      this.sensorDetails = data;
      this.detailsIndex = this.sensorDetails.findIndex(
        (x) => x.id === this.sensorId
      );
    });
  }

  openRenameDialog(): void {
    if (this.detailsIndex !== undefined) {
      const dialogRef = this.dialog.open(RenameDialogComponent, {
        data: { name: this.sensorDetails[this.detailsIndex].name },
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          this.detailsService.updateSensorDetails({
            id: this.sensorId,
            name: result,
          });
        }
      });
    }
  }

  openDeleteDialog(): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.detailsService.deleteSensorDetails(this.sensorId);
      }
    });
  }
}
